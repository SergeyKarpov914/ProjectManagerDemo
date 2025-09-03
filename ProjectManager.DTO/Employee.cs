using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[Employee]")]
    public class Employee : IEntity
    {
        [Column("Id")][PKey] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Code")] public string Code { get; set; }
        [Column("FirstName")] public string FirstName { get; set; }
        [Column("LastName")] public string LastName { get; set; }
        [Column("CorporateTitle")] public string CorporateTitle { get; set; }
        [Column("LocationCode")] public string LocationCode { get; set; }
        [Column("Discipline")] public string Discipline { get; set; }
        [Column("JobGroupDescription")] public string JobGroupDescription { get; set; }

        #region dataaccess

        public static IDataAccess<Employee> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new EmployeeDataAccess(gateway, cache);
        }
        private static IDataAccess<Employee> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IEmployeeDataAccess : IDataAccess<Employee> { }

    public sealed class EmployeeDataAccess : DataAccessMaster<Employee>, IEmployeeDataAccess
    {
        public EmployeeDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
