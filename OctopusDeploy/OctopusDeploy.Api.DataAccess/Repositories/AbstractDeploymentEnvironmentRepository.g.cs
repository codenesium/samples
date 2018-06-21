using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractDeploymentEnvironmentRepository : AbstractRepository
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

                public virtual Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                public async Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.Where(x => x.DataVersion == dataVersion);

                        return records;
                }

                protected async Task<List<DeploymentEnvironment>> Where(
                        Expression<Func<DeploymentEnvironment, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<DeploymentEnvironment, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<DeploymentEnvironment>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentEnvironment>();
                        }
                        else
                        {
                                return await this.Context.Set<DeploymentEnvironment>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<DeploymentEnvironment>();
                        }
                }

                private async Task<DeploymentEnvironment> GetById(string id)
                {
                        List<DeploymentEnvironment> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>d50f30c4d64823531ab49526ad540286</Hash>
</Codenesium>*/