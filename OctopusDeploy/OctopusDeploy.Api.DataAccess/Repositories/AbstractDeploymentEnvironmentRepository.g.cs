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
        public abstract class AbstractDeploymentEnvironmentRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDeploymentEnvironmentRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DeploymentEnvironment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<DeploymentEnvironment> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<DeploymentEnvironment> Create(DeploymentEnvironment item)
                {
                        this.Context.Set<DeploymentEnvironment>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DeploymentEnvironment item)
                {
                        var entity = this.Context.Set<DeploymentEnvironment>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<DeploymentEnvironment>().Attach(item);
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
                        DeploymentEnvironment record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DeploymentEnvironment>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<DeploymentEnvironment> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.SearchLinqEF(x => x.DataVersion == dataVersion);

                        return records;
                }

                protected async Task<List<DeploymentEnvironment>> Where(Expression<Func<DeploymentEnvironment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<DeploymentEnvironment> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<DeploymentEnvironment>> SearchLinqEF(Expression<Func<DeploymentEnvironment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentEnvironment.Id)} ASC";
                        }

                        return await this.Context.Set<DeploymentEnvironment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DeploymentEnvironment>();
                }

                private async Task<List<DeploymentEnvironment>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DeploymentEnvironment.Id)} ASC";
                        }

                        return await this.Context.Set<DeploymentEnvironment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DeploymentEnvironment>();
                }

                private async Task<DeploymentEnvironment> GetById(string id)
                {
                        List<DeploymentEnvironment> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>69dd32e0ecf135349ef700c76f8ef547</Hash>
</Codenesium>*/