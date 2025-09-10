using Clio.ProjectManagerModel.ViewModel.Element;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel.Content
{
    public sealed class ProjectContent : PresentationContent
    {
        public ProjectContent(IPresentationContent viewModel) : base(viewModel)
        {
            ContentType = ContentType.Project;
        }

        public ObservableCollection<ProjectElement> ProjectElements => _viewModel.ProjectElements;

        public ICommand OpenExcelFileCommand => _viewModel.OpenExcelFileCommand;
        public ICommand OpenCsvFileCommand => _viewModel.OpenCsvFileCommand;
    }
}
