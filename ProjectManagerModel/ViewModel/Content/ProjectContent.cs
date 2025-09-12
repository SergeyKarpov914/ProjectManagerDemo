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
        
        public ICommand SaveCommand    => _viewModel.SaveCommand;
        public ICommand DeleteCommand  => _viewModel.DeleteCommand;

        public static IPMViewModel ViewModel { get; set; }
        public static ICommand Save => ViewModel.SaveCommand;
        public static ICommand Delete => ViewModel.DeleteCommand;
    
        public ProjectElement SelectedItem { get; set; }
    }
}
