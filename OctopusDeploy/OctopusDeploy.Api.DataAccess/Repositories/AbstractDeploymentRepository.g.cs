using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractDeploymentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeploymentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Deployment>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Deployment> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Deployment> Create(Deployment item)
                {
                        this.Context.Set<Deployment>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Deployment item)
                {
                        var entity = this.Context.Set<Deployment>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Deployment>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        Deployment record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Deployment>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Deployment>> GetChannelId(string channelId)
                {
                        var records = await this.SearchLinqEF(x => x.ChannelId == channelId);

                        return records;
                }
                public async Task<List<Deployment>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId)
                {
                        var records = await this.SearchLinqEF(x => x.Id == id && x.ProjectId == projectId && x.ProjectGroupId == projectGroupId && x.Name == name && x.Created == created && x.ReleaseId == releaseId && x.TaskId == taskId && x.EnvironmentId == environmentId);

                        return records;
                }
                public async Task<List<Deployment>> GetTenantId(string tenantId)
                {
                        var records = await this.SearchLinqEF(x => x.TenantId == tenantId);

                        return records;
                }

                protected async Task<List<Deployment>> Where(Expression<Func<Deployment, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Deployment> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Deployment>> SearchLinqEF(Expression<Func<Deployment, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Deployment.Id)} ASC";
                        }

                        return await this.Context.Set<Deployment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Deployment>();
                }

                private async Task<List<Deployment>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Deployment.Id)} ASC";
                        }

                        return await this.Context.Set<Deployment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Deployment>();
                }

                private async Task<Deployment> GetById(string id)
                {
                        List<Deployment> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<DeploymentRelatedMachine>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<DeploymentRelatedMachine>().Where(x => x.DeploymentId == deploymentId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DeploymentRelatedMachine>();
                }
        }
}

/*<Codenesium>
    <Hash>733b5d70a051463157bc1a6085bba01b</Hash>
</Codenesium>*/