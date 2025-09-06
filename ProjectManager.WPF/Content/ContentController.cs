using Clio.ProjectManager.WPF.ViewModel;
using Clio.ProjectManagerModel.ViewModel;
using Syncfusion.Windows.Controls.Gantt;
using System.Collections.ObjectModel;

namespace Clio.ProjectManager.WPF.Content
{
    public class ContentController : IContentController
    {
        private IProjectManagerViewModel _viewModel = null;

        private Projects _projects = null;
        private Tasks    _tasks    = null;

        public object SetContent(string name, IProjectManagerViewModel viewModel)
        {
            _viewModel ??= viewModel;

            object content = null;
            
            switch (name)
            {
                case "Projects":
                    if(_tasks is not null) _tasks.TaskCollection = new ObservableCollection<TaskDetails>();
                    content = _projects ??= new Projects(viewModel);
                    break;
                case "Tasks":
                    content = _tasks ??= new Tasks(viewModel);
                    break;
                case "Participants":
                    if (_tasks is not null) _tasks.TaskCollection = null;
                    break;
            }
            return content;
        }
    }
}
