using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[ProjectType]")]
    public sealed class ProjectType : IEntity
    {
        [Column("Id")][PKey] public int Id { get; set; }
        [Column("Code")] public string Code { get; set; }
        [Column("Name")] public string Name { get; set; }

        #region dataaccess

        public static IDataAccess<ProjectType> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new ProjectTypeDataAccess(gateway, cache);
        }
        private static IDataAccess<ProjectType> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IProjectTypeDataAccess : IDataAccess<ProjectType> { }

    public sealed class ProjectTypeDataAccess : DataAccessMaster<ProjectType>, IProjectTypeDataAccess
    {
        public ProjectTypeDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
