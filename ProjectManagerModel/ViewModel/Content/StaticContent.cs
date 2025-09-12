using Clio.ProjectManager.DTO;
using System.Collections.Generic;

namespace Clio.ProjectManagerModel.ViewModel.Content
{
    public sealed class StaticContent : PresentationContent
    {
        public StaticContent(IPMViewModel viewModel) : base( viewModel)
        {
            ContentType = ContentType.Static;
        }
        public IEnumerable<Client>   Clients   => _viewModel.Clients;
        public IEnumerable<Employee> Employees => _viewModel.Employees ;
    }
}
