using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Master;
using Clio.ProjectManager.DTO;
using Clio.ProjectManagerModel.ViewModel.Element;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel
{
    public interface IPresentationContent
    {
        ObservableCollection<ProjectElement> ProjectElements { get; }
        ObservableCollection<TaskElement> TaskElements { get; }

        ICommand OpenExcelFileCommand { get; }
        ICommand OpenCsvFileCommand { get; }

    }

    #region content types

    public sealed class ProjectContent
    {
        private readonly IPresentationContent _viewModel;

        public ProjectContent(IPresentationContent viewModel)
        {
            _viewModel = viewModel;
        }

        public ObservableCollection<ProjectElement> ProjectElements => _viewModel.ProjectElements;

        public ICommand OpenExcelFileCommand => _viewModel.OpenExcelFileCommand;
        public ICommand OpenCsvFileCommand => _viewModel.OpenCsvFileCommand;
    }
    public sealed class TaskContent
    {
        private readonly IPresentationContent _viewModel;

        public TaskContent(IPresentationContent viewModel)
        {
            _viewModel = viewModel;
        }

        //ObservableCollection<ProjectElement> TaskElements => _viewModel.TaskElements;

        public ICommand OpenExcelFileCommand => _viewModel.OpenExcelFileCommand;
        public ICommand OpenCsvFileCommand => _viewModel.OpenCsvFileCommand;
    }

    #endregion content types

    public partial class ProjectManagerViewModel : ObservableObject, IPresentationContent
    {
        public ProjectManagerViewModel Initialize(IWinAccess winAccess)
        {
            ContentSwitchCommand = MvvmMaster.CreateCommand<string>(ResolveContent);
            OpenExcelFileCommand = MvvmMaster.CreateCommand<string>(OpenExcelFile);
            OpenCsvFileCommand = MvvmMaster.CreateCommand<string>(OpenCsvFile);

            _projectContent = new ProjectContent(this);
            _taskContent = new TaskContent(this);

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
        public ObservableCollection<TaskElement> TaskElements { get; private set; } = new ObservableCollection<TaskElement>();

        private async void RefreshProjects(IEnumerable<Project> projects)
        {
            if (projects is not null)
            {
                ProjectElements.Clear();

                foreach (Project project in projects)
                {
                    ProjectElements.Add(ProjectElement.Create(project));
                }
            }
        }

        #endregion collections

        #region commands

        public ICommand ContentSwitchCommand { get; private set; }

        private void ResolveContent(string name)
        {
            switch (name)
            {
                case "Projects":
                    Content = _projectContent;
                    break;
                case "Tasks":
                    Content = _taskContent;
                    break;
                case "Participants":
                    break;
            }
        }

        public ICommand OpenExcelFileCommand { get; private set; }

        private async void OpenExcelFile(string name)
        {
            if (null != (name = _winAccess.SelectFile()))
            {
                IEnumerable<Project> projects = await _excelMaster.ImportFromExcel<Project>(name);
                RefreshProjects(projects);
            }
        }

        public ICommand OpenCsvFileCommand { get; private set; }

        private void OpenCsvFile(string name)
        {
            if (null != (name = _winAccess.SelectFile()))
            {
                IEnumerable<Project> projects = _csvAdapter.Parse<Project>(name);
            }
        }

        #endregion commands

        #region fields

        private ProjectContent _projectContent = null;
        private TaskContent _taskContent = null;

        private IWinAccess _winAccess = null;

        #endregion fields
    }
}
