using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[Project]")]
    public sealed class Project : IEntity
    {
        [Column("Id")][PKey] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Code")][Unique] public string Code { get; set; }

        [Column("ClientID")][FKey] public int ClientId { get; set; }
        [Column("ProjectTypeID")][FKey] public int ProjectTypeId { get; set; }
        [Column("EmployeeCode")] public string EmployeeCode { get; set; }

        [Column("AccountingName")] public string AccountingName { get; set; }

        public override string ToString() { return $"Project: {Name} (code: {Code})"; }

        #region dataaccess

        public static IDataAccess<Project> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new ProjectDataAccess(gateway, cache);
        }
        private static IDataAccess<Project> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IProjectDataAccess : IDataAccess<Project> { }

    public sealed class ProjectDataAccess : DataAccessMaster<Project>, IProjectDataAccess
    {
        public ProjectDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
