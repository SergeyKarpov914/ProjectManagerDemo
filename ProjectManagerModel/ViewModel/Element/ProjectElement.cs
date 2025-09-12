using Acsp.Core.Lib.Abstraction;
using Clio.ProjectManager.DTO;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Clio.ProjectManagerModel.ViewModel.Element
{
    public sealed class ProjectElement : ObservableObject, IElement
    {
        public IEntity Entity { get; private set; }

        public ProjectElement()
        {
            Entity = new Project();
        }

        public IElement SetRelations(IEntity entity = null)
        {
            Entity = entity;
            return this;
        }

        public static ProjectElement Create(Project project, IPMViewModel vm)
        {
            ProjectElement element = new ProjectElement().SetRelations(project) as ProjectElement;

            IEntity subEntity = null;

            if (null != (subEntity = vm.Clients.FirstOrDefault(x => x.Id == project.ClientId)))
            {
                element.Client = subEntity.Name;
            }
            if (null != (subEntity = vm.Employees.FirstOrDefault(x => x.Id == project.EmployeeId)))
            { 
                element.Employee = subEntity.Name;                
            }
            if (null != (subEntity = vm.ProjectTypes.FirstOrDefault(x => x.Id == project.ProjectTypeId)))
            {
                element.ProjectType = subEntity.Name;
            }
            element.AccountingName = project.AccountingName;

            return element;
        }

        public string Name          { get { return Entity.Name; } set { Entity.Name = value; } }
        public string Code          { get { return Entity.Code; } set { Entity.Code = value; } }

        public string Client         { get; set; }
        public string ProjectType    { get; set; }
        public string Employee       { get; set; }
        public string AccountingName { get; set; }
    }
}
