using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[ProjectRateSchedule]")]
    public sealed class ProjectRateType : IEntity
    {
        [Column("ID")][PKey] public int Id { get; set; }
        [Column("Code")] public string Code { get; set; }
        [Column("Name")] public string Name { get; set; }

        #region dataaccess

        public static IDataAccess<ProjectRateType> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new RateScheduleTypeDataAccess(gateway, cache);
        }
        private static IDataAccess<ProjectRateType> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IRateScheduleTypeDataAccess : IDataAccess<ProjectRateType> { }

    public sealed class RateScheduleTypeDataAccess : DataAccessMaster<ProjectRateType>, IRateScheduleTypeDataAccess
    {
        public RateScheduleTypeDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
