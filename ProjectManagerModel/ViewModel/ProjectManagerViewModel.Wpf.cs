using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Extension;
using Acsp.Core.Lib.Master;
using Clio.ProjectManager.DTO;
using Clio.ProjectManagerModel.ViewModel.Content;
using Clio.ProjectManagerModel.ViewModel.Element;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel
{
    #region content (datatemplate) types

    public enum ContentType { Project, Task, Static, None }

    public abstract class PresentationContent                      // vm composition is used instead of inheritance, 
    {                                                              // because vm is injected as singleton and itself depends on constructor injection
        protected readonly IPMViewModel _viewModel;

        protected PresentationContent(IPMViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        protected ContentType ContentType { get; set; } = ContentType.None;
    }

    #endregion content (datatemplate) types

    public partial class ProjectManagerViewModel : ObservableObject, IPMViewModel
    {
        #region fields

        private ProjectContent _projectContent = null;
        private StaticContent _staticContent = null;

        //      private TaskContent _taskContent = null;          // TEMP
        private object _taskContent = null;

        private IWinAccess _winAccess = null;

        #endregion fields

        public ProjectManagerViewModel Initialize(IWinAccess winAccess, /*TEMP*/ object taskContent)
        {
            ContentSwitchCommand = MvvmMaster.CreateAsyncCommand<string>(ResolveContent);
            
            OpenExcelFileCommand = MvvmMaster.CreateCommand<string>(OpenExcelFile);
            OpenCsvFileCommand   = MvvmMaster.CreateCommand<string>(OpenCsvFile);
            AddProjectCommand    = MvvmMaster.CreateCommand<string>(OnProjectAdd);
            RowValidatingCommand = MvvmMaster.CreateCommand<string>(OnProjectValidating);
            DeleteProjectCommand = MvvmMaster.CreateCommand<string>(OnProjectDelete);

            _projectContent = new ProjectContent(this);
            _staticContent = new StaticContent(this);
            _taskContent = taskContent; // TEMP new TaskContent(this);

            _winAccess = winAccess;

            return this;
        }

        #region props 

        public object Content
        {
            get { return _content; }
            private set { _content = value; this.OnPropertyChanged(nameof(Content)); }
        }
        private object _content;

        #endregion props 

        #region collections

        public ObservableCollection<ProjectElement> ProjectElements { get; private set; } = new ObservableCollection<ProjectElement>();
        public ObservableCollection<TaskElement>    TaskElements    { get; private set; } = new ObservableCollection<TaskElement>();

        public IEnumerable<Client>      Clients      { get; private set; } = Enumerable.Empty<Client>();
        public IEnumerable<Employee>    Employees    { get; private set; } = Enumerable.Empty<Employee>();
        public IEnumerable<ProjectType> ProjectTypes { get; private set; } = Enumerable.Empty<ProjectType>();

        private async Task RefreshProjectCollection(IEnumerable<Project> projects, bool doClear = false)
        {
            if (doClear)
            {
                ProjectElements.Clear();
            }
            if (!projects.IsEmpty())
            {
                foreach (Project project in projects)
                {
                    ProjectElements.Add(ProjectElement.Create(project, this));
                }
            }
            await Task.Delay(0);
        }

        private async Task GetProjects()
        {
            await GetStaticEntities();
            await RefreshProjectCollection(await _processor.GetProjects());
        }

        private async Task GetStaticEntities()
        {
            Clients      = await _processor.GetClients();
            Employees    = await _processor.GetEmployees();
            ProjectTypes = await _processor.GetProjectTypes();
        }

        #endregion collections

        #region commands

        public ICommand ContentSwitchCommand { get; private set; }
        public ICommand OpenExcelFileCommand { get; private set; }
        public ICommand OpenCsvFileCommand   { get; private set; }
        public ICommand AddProjectCommand    { get; private set; }
        public ICommand RowValidatingCommand { get; private set; }
        public ICommand DeleteProjectCommand { get; private set; }


        private async Task ResolveContent(string name)
        {
            ContentType content = name.ToEnum<ContentType>(ContentType.None);
            
            switch (content)
            {
                case ContentType.Project:
                    await GetProjects();
                    Content = _projectContent;
                    break;
                case ContentType.Task:
                    Content = _taskContent;
                    break;
                case ContentType.Static:
                    await GetStaticEntities();
                    Content = _staticContent;
                    break;
                default:
                    throw new System.Exception($"Cannot resolve content '{name}'");
            }
        }

        private async void OpenExcelFile(string name)
        {
            if (null != (name = _winAccess.SelectFile()))
            {
                await RefreshProjectCollection(await _excelMaster.ImportFromExcel<Project>(name));
            }
        }

        private void OpenCsvFile(string name)
        {
            if (null != (name = _winAccess.SelectFile()))
            {
                IEnumerable<Project> projects = _csvAdapter.Parse<Project>(name);
            }
        }

        private void OnProjectAdd(string name)
        {
            _winAccess.ShowNotification("Start adding new project");
        }

        private void OnProjectValidating(string name)
        {
            _winAccess.ShowNotification("New project is on it's way");
        }

        private void OnProjectDelete(string name)
        {
            _winAccess.ShowNotification("Delete order. Who do you think you are? Nigel Mansell?", Notification.Error, 5000);
        }

        #endregion commands
    }
}
