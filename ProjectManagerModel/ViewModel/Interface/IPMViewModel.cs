using Clio.ProjectManager.DTO;
using Clio.ProjectManagerModel.ViewModel.Element;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel
{
    public interface IPMViewModel
    {
        ObservableCollection<ProjectElement> ProjectElements { get; }
        ObservableCollection<TaskElement> TaskElements { get; }

        public IEnumerable<Client> Clients { get; }
        public IEnumerable<Employee> Employees { get; }
        public IEnumerable<ProjectType> ProjectTypes { get; }

        ICommand OpenExcelFileCommand { get; }
        ICommand OpenCsvFileCommand   { get; }
        ICommand AddProjectCommand    { get; }
        ICommand RowValidatingCommand { get; }
        ICommand DeleteProjectCommand { get; }
    }
}
