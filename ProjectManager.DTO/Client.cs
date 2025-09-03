using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[Client]")]
    public sealed class Client : IEntity
    {
        [Column("ID")][PKey] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Code")] public string Code { get; set; }
        [Column("Company")] public string Company { get; set; }
        [Column("Address")] public string Address { get; set; }
        [Column("City")] public string City { get; set; }
        [Column("State")] public string State { get; set; }
        [Column("Country")] public string Country { get; set; }
        [Column("Classification")] public string Classification { get; set; }

        #region dataaccess

        public static IDataAccess<Client> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new ClientDataAccess(gateway, cache);
        }
        private static IDataAccess<Client> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IClientDataAccess : IDataAccess<Client> { }

    public sealed class ClientDataAccess : DataAccessMaster<Client>, IClientDataAccess
    {
        public ClientDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
