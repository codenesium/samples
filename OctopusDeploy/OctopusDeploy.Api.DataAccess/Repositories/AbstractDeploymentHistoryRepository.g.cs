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
        public abstract class AbstractDeploymentHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeploymentHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DeploymentHistory>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<DeploymentHistory> Get(string deploymentId)
                {
                        return await this.GetById(deploymentId);
                }

                public async virtual Task<DeploymentHistory> Create(DeploymentHistory item)
                {
                        this.Context.Set<DeploymentHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DeploymentHistory item)
                {
                        var entity = this.Context.Set<DeploymentHistory>().Local.FirstOrDefault(x => x.DeploymentId == item.DeploymentId);
                        if (entity == null)
                        {
                                this.Context.Set<DeploymentHistory>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string deploymentId)
                {
                        DeploymentHistory record = await this.GetById(deploymentId);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DeploymentHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<DeploymentHistory>> GetCreated(DateTimeOffset created)
                {
                        var records = await this.SearchLinqEF(x => x.Created == created);

                        return records;
                }

                protected async Task<List<DeploymentHistory>> Where(Expression<Func<DeploymentHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<DeploymentHistory> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<DeploymentHistory>> SearchLinqEF(Expression<Func<DeploymentHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentHistory.DeploymentId)} ASC";
                        }

                        return await this.Context.Set<DeploymentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeploymentHistory>();
                }

                private async Task<List<DeploymentHistory>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentHistory.DeploymentId)} ASC";
                        }

                        return await this.Context.Set<DeploymentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DeploymentHistory>();
                }

                private async Task<DeploymentHistory> GetById(string deploymentId)
                {
                        List<DeploymentHistory> records = await this.SearchLinqEF(x => x.DeploymentId == deploymentId);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a6a5bbc8d5e6f162eefeddad49b9f56a</Hash>
</Codenesium>*/