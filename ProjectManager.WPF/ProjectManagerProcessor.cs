using Acsp.Core.Lib.Abstraction;
using Acsp.Core.Lib.Data;
using Acsp.Core.Lib.Extension;
using Acsp.Core.Lib.Gateway;
using Acsp.Core.Lib.Master;
using Acsp.Core.Lib.Pattern;
using Acsp.Core.Lib.Util;
using Acsp.Core8.Asp.Net;
using Clio.ProjectManager.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clio.ProjectManagerModel
{
    public sealed class ProcessorDependencies : DependencyMaster
    {
        protected override void cascadeDependencies(IServiceCollection container)
        {
            container.AddTransient<ISqlGateway, SqlDapperGateway>();
            container.AddSingleton<IDataAccessCache, DataAccessCache>();
        }
    }

    public sealed class ProjectManagerProcessor
    {
        #region type dependency 

        public static DependencyMaster CascadeDependencies()
        {
            return new ProcessorDependencies();
        }

        public static void Mark(IConfigurationRoot configuration, IServiceCollection services, Env environment)
        {
            LogUtil.RuntimeInfo(typeof(ProjectManagerProcessor), $"Blazor Processor start", environment, null, new Type[]
            {
                typeof(EntityMaster),// CoreLib
                typeof(AspNetCore),  // Core8
                typeof(Project),     //
                typeof(ProjectManagerProcessor),
            });
            AspNetCore.ProcessDIContainer(typeof(ProjectManagerProcessor), configuration, services);
            LogUtil.ConfigurationContent(typeof(ProjectManagerProcessor), configuration);
        }

        #endregion type dependency 

        #region c-tor

        private readonly IDataAccessCache _cache;
        private readonly ISqlGateway _sqlGateway;

        public ProjectManagerProcessor(ISqlGateway sqlGateway, IDataAccessCache cache)
        {
            sqlGateway.Inject<ISqlGateway>(out _sqlGateway);
            cache.Inject(out _cache);
        }

        #endregion c-tor

        #region get entity collections

        public async Task<IEnumerable<Project>> GetProjects(IEnumerable<int> ids = null)
        {
            IEnumerable<Project> projects = Enumerable.Empty<Project>(); ;
            try
            {
                projects = await Project.DataAccess(_sqlGateway, _cache).Read(ids.ToInClause<int>("[Id]"));
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return projects;
        }

        public async Task<IEnumerable<ProjectTask>> GetTasks(int projectId = 0)
        {
            IEnumerable<ProjectTask> tasks = Enumerable.Empty<ProjectTask>(); ;
            try
            {
                tasks = await ProjectTask.DataAccess(_sqlGateway, _cache).Read(projectId > 0 ? $"WHERE ProjectId = {projectId}" : null);

                //populateSubTasks(tasks);
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return tasks;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> entities = Enumerable.Empty<Employee>();
            try
            {
                entities = await Employee.DataAccess(_sqlGateway, _cache).Read();
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return entities;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            IEnumerable<Client> entities = Enumerable.Empty<Client>();
            try
            {
                entities = await Client.DataAccess(_sqlGateway, _cache).Read();
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return entities;
        }

        public async Task<IEnumerable<Deliverable>> GetDeliverables(int projectId = 0)
        {
            IEnumerable<Deliverable> items = Enumerable.Empty<Deliverable>();
            try
            {
                items = await Deliverable.DataAccess(_sqlGateway, _cache).Read($"WHERE [ProjectID] = {projectId}");
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return items;
        }

        #endregion get entity collections

        #region entity crud

        public async Task<IEnumerable<E>> ReedSet<E>(string clause = null) where E : class, IEntity
        {
            IEnumerable<E> set = Enumerable.Empty<E>();
            try
            {
                set = await EntityEx.RunReed<E>(_sqlGateway, _cache, clause);
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
            return set;
        }

        public async Task Create(IEntity entity, string clause = null) // clause is never used in create, but use it here for uniformal param count in RunCUD
        {
            try
            {
                await entity.RunCUD(nameof(Create), _sqlGateway, _cache, clause);
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
        }
        public async Task Update(IEntity entity, string clause = null)
        {
            try
            {
                await entity.RunCUD(nameof(Update), _sqlGateway, _cache, clause);
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
        }
        public async Task Delete(IEntity entity, string clause = null)
        {
            try
            {
                await entity.RunCUD(nameof(Delete), _sqlGateway, _cache, clause);
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
                throw;
            }
        }

        #endregion entity crud
    }
}