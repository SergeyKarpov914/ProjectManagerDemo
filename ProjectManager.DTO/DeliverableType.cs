using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[DeliverableType]")]
    public sealed class DeliverableType : IEntity
    {
        [Column("Id")][PKey] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Code")] public string Code { get; set; }

        #region dataaccess

        public static IDataAccess<DeliverableType> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new DeliverableTypeDataAccess(gateway, cache);
        }
        private static IDataAccess<DeliverableType> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IDeliverableTypeDataAccess : IDataAccess<DeliverableType> { }

    public sealed class DeliverableTypeDataAccess : DataAccessMaster<DeliverableType>, IDeliverableTypeDataAccess
    {
        public DeliverableTypeDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
