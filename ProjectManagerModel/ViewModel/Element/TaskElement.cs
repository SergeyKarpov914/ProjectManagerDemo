using Acsp.Core.Lib.Abstraction;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clio.ProjectManagerModel.ViewModel.Element
{
    public sealed class TaskElement : ObservableObject, IElement
    {
        public IEntity Entity => throw new System.NotImplementedException();

        public IElement SetRelations(IEntity owner = null)
        {
            return this;
        }
    }
}
