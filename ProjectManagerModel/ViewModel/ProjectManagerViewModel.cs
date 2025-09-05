using Acsp.Core.Lib.Extension;
using Acsp.Core.Lib.Master;
using Microsoft.Extensions.DependencyInjection;

namespace Clio.ProjectManagerModel.ViewModel
{
    public sealed class ViewModelDependencies : DependencyMaster
    {
        protected override void cascadeDependencies(IServiceCollection container)
        {
            typeof(ProjectManagerProcessor).RegisterCascading(container, () => container.AddTransient<ProjectManagerProcessor>());
            container.AddTransient<ExcelMaster>();
        }
    }

    public sealed partial class ProjectManagerViewModel
    {
        public static DependencyMaster CascadeDependencies()
        {
            return new ViewModelDependencies();
        }

        #region c-tor

        private readonly ExcelMaster _excelMaster;
        private readonly ProjectManagerProcessor _processor;

        public ProjectManagerViewModel(ProjectManagerProcessor processor, ExcelMaster excelMaster)
        {
            processor.Inject(out _processor);
            excelMaster.Inject(out _excelMaster);
        }

        public ProjectManagerProcessor Processor => _processor;

        #endregion c-tor            
    }
}
