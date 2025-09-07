using Acsp.Core.Lib.Abstraction;
using Clio.ProjectManager.DTO;

namespace Clio.ProjectManagerModel.ViewModel.Element
{
    public sealed class ProjectElement : IElement
    {
        public IEntity Entity { get; private set; }

        public IElement SetRelations(IEntity owner = null)
        {
            return this;
        }

        public static ProjectElement Create(Project project)
        {
            ProjectElement element = new ProjectElement();

            element.Entity = project;
            element.SetRelations(project);

            return element;
        }

        public string Name           => Entity.Name;
        public string Code           => Entity.Code;

        public int    Client         { get; set; }
        public int    ProjectType    { get; set; }
        public string Employee       { get; set; }
        public string AccountingName { get; set; }
    }
}
