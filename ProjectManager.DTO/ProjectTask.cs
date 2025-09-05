using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Master;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clio.ProjectManager.DTO
{
    [Table("[dbo].[Task]")]
    public class ProjectTask : IEntity
    {
        [Column("Id")][PKey]        public int      Id           { get; set; }
        [Column("Name")]            public string   Name         { get; set; }
        [Column("Code")]            public string   Code         { get; set; }
        [Column("ProjectId")][FKey] public int      ProjectId    { get; set; }
        [Column("ParentTaskId")]    public int      ParentTaskId { get; set; }
        [Column("Percent")]         public decimal  Percent      { get; set; }
        [Column("StartDate")]       public DateTime StartDate    { get; set; }

        #region dataaccess

        public static IDataAccess<ProjectTask> DataAccess(IDataGateway gateway, IDataAccessCache cache)
        {
            return _dataAccess ??= new TaskDataAccess(gateway, cache);
        }
        private static IDataAccess<ProjectTask> _dataAccess = null;

        #endregion dataaccess
    }

    public interface ITaskDataAccess : IDataAccess<ProjectTask> { }

    public sealed class TaskDataAccess : DataAccessMaster<ProjectTask>, ITaskDataAccess
    {
        public TaskDataAccess(IDataGateway gateway, IDataAccessCache cache) : base(gateway, cache)
        {
        }
    }
}
