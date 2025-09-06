using Acsp.Core.Lib.Master;
using Clio.ProjectManager.DTO;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel
{
    public interface IProjectManagerViewModel
    {
        IEnumerable<Project> Projects { get; }
    }
    public interface IContentController
    {
        object SetContent(string name, IProjectManagerViewModel viewModel);
    }

    public partial class ProjectManagerViewModel : ObservableObject, IProjectManagerViewModel
    {
        private IContentController _contentController;
        
        public ProjectManagerViewModel Initialize(IContentController contentController)
        {
            ContentSwitchCommand = MvvmMaster.CreateCommand<string>(ResolveContent);
            OpenExcelFileCommand = MvvmMaster.CreateCommand<string>(OpenExcelFile);
            OpenCsvFileCommand   = MvvmMaster.CreateCommand<string>(OpenCsvFile);

            Projects = new List<Project>() { new Project() { Name = "First project" }, new Project() { Name = "Second project"} };
            
            
            _contentController = contentController;
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

        public IEnumerable<Project> Projects { get; set; }

        #endregion collections

        public ICommand ContentSwitchCommand { get; private set; }

        private void ResolveContent(string name)
        {
            Content = _contentController.SetContent(name, this);
        }

        public ICommand OpenExcelFileCommand { get; private set; }

        private async void OpenExcelFile(string name)
        {
            IEnumerable<Project> projects = await _excelMaster.ImportFromExcel<Project>(name);
        }

        public ICommand OpenCsvFileCommand { get; private set; }

        private void OpenCsvFile(string name)
        {
            IEnumerable<Project> projects = _csvAdapter.Parse<Project>(name);
        }
    }
}
