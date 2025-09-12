using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Extension;
using Acsp.Core.Lib.Gateway;
using Acsp.Core.Lib.Master;
using Clio.ProjectManager.DTO;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clio.ProjectManagerModel.ViewModel
{
    public sealed class ViewModelDependencies : DependencyMaster
    {
        protected override void cascadeDependencies(IServiceCollection container)
        {
            typeof(ProjectManagerProcessor).RegisterCascading(container, () => container.AddTransient<ProjectManagerProcessor>());
            container.AddTransient<ExcelMaster>();
            container.AddTransient<CsvAdapter>();
        }
    }

    public partial class ProjectManagerViewModel
    {
        public static DependencyMaster CascadeDependencies()
        {
            return new ViewModelDependencies();
        }

        #region c-tor

        private readonly CsvAdapter  _csvAdapter;
        private readonly ExcelMaster _excelMaster;
        private readonly ProjectManagerProcessor _processor;

        public ProjectManagerViewModel(ProjectManagerProcessor processor, ExcelMaster excelMaster, CsvAdapter csvAdapter)
        {
            processor.Inject(out _processor);
            excelMaster.Inject(out _excelMaster);
            csvAdapter.Inject(out _csvAdapter);
        }

        public ProjectManagerProcessor Processor => _processor;

        #endregion c-tor            

        #region read-only collections

        public IEnumerable<Client> Clients { get; private set; } = Enumerable.Empty<Client>();
        public IEnumerable<Employee> Employees { get; private set; } = Enumerable.Empty<Employee>();
        public IEnumerable<ProjectType> ProjectTypes { get; private set; } = Enumerable.Empty<ProjectType>();

        private async Task GetStaticEntities()
        {
            Clients = await _processor.GetClients();
            Employees = await _processor.GetEmployees();
            ProjectTypes = await _processor.GetProjectTypes();
        }

        #endregion read-only collections

        public async Task Delete(IElement element)
        {
            await _processor.Delete(element.Entity);        
        }
    }
}
