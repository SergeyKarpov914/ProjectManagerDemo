using Clio.ProjectManagerModel.ViewModel.Element;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel.Content
{
    public sealed class ProjectContent : PresentationContent
    {
        public ProjectContent(IPMViewModel viewModel) : base(viewModel)
        {
            ContentType = ContentType.Project;
            ViewModel = viewModel;
        }
        public ObservableCollection<ProjectElement> ProjectElements => _viewModel.ProjectElements;

        public ICommand OpenExcelFileCommand => _viewModel.OpenExcelFileCommand;
        public ICommand OpenCsvFileCommand   => _viewModel.OpenCsvFileCommand;
        public ICommand AddProjectCommand    => _viewModel.AddProjectCommand;
        public ICommand RowValidatingCommand => _viewModel.RowValidatingCommand;
        public ICommand DeleteProjectCommand => _viewModel.DeleteProjectCommand;

        public static IPMViewModel ViewModel { get; set; }
        public static ICommand Delete => ViewModel.DeleteProjectCommand;
    }
}
