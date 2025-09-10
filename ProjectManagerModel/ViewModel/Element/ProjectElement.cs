using Acsp.Core.Lib.Abstraction;
using Clio.ProjectManager.DTO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Clio.ProjectManagerModel.ViewModel.Element
{
    public sealed class ProjectElement : ObservableObject, IElement
    {
        public IEntity Entity { get; private set; }

        public ProjectElement()
        {
            Entity = new Project();
        }

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

        public string Name          { get { return Entity.Name; } set { Entity.Name = value; } }
        public string Code          { get { return Entity.Code; } set { Entity.Code = value; } }

        public int    Client         { get; set; }
        public int    ProjectType    { get; set; }
        public string Employee       { get; set; }
        public string AccountingName { get; set; }
    }
}
