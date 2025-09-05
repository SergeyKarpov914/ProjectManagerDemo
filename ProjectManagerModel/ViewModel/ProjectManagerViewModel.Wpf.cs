using Acsp.Core.Lib.Master;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Clio.ProjectManagerModel.ViewModel
{
    public interface IProjectManagerViewModel
    {
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
            ContentSwitchCommand = MvvmMaster.CreateCommand<string>(SetContent);


            _contentController = contentController;
            return this;
        }

        public ICommand ContentSwitchCommand { get; private set; }

        public object   Content              
        {
            get         { return _content; }
            private set { _content = value; this.OnPropertyChanged(nameof(Content)); } 
        }
        private object _content;

        private void SetContent(string name)
        {
            Content = null;
            Content = _contentController.SetContent(name, this);
        }
    }
}
