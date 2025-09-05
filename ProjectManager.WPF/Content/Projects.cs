using Clio.ProjectManager.DTO;
using Clio.ProjectManagerModel.ViewModel;

namespace Clio.ProjectManager.WPF.ViewModel
{
    public class Projects
    {
        private readonly IProjectManagerViewModel _viewModel;

        public Projects(IProjectManagerViewModel viewModel) 
        { 
            _viewModel = viewModel; 
        }

        public IEnumerable<Project> AllProjects => _viewModel.Projects;
    }
}
