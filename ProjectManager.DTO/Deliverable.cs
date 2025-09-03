using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[Deliverable]")]
    public sealed class Deliverable : IEntity
    {
        [Column("Id")][PKey] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Code")] public string Code { get; set; }
        [Column("TaskID")][FKey] public int ProjectID { get; set; }
        [Column("DeliverableTypeID")][FKey] public int DeliverableTypeID { get; set; }
        [Column("DisciplineID")][FKey] public int DisciplineID { get; set; }
        [Column("Quantity")] public int Quantity { get; set; }
        [Column("Description")] public string Description { get; set; }

        #region dataaccess

        public static IDataAccess<Deliverable> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new DeliverableDataAccess(gateway, cache);
        }
        private static IDataAccess<Deliverable> _dataAccess = null;

        #endregion dataaccess
    }

    public interface IDeliverableDataAccess : IDataAccess<Deliverable> { }

    public sealed class DeliverableDataAccess : DataAccessMaster<Deliverable>, IDeliverableDataAccess
    {
        public DeliverableDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }

        protected override string composeReadQuery(string clause = null)
        {
            return clause is null ? base.composeReadQuery() : base.composeReadQuery(clause);
        }
    }
}
