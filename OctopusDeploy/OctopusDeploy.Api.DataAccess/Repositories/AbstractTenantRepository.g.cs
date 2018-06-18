using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractTenantRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTenantRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Tenant> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Tenant> Create(Tenant item)
                {
                        this.Context.Set<Tenant>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Tenant item)
                {
                        var entity = this.Context.Set<Tenant>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Tenant>().Attach(item);
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
                        Tenant record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Tenant>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Tenant> GetName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<List<Tenant>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.Where(x => x.DataVersion == dataVersion);

                        return records;
                }

                protected async Task<List<Tenant>> Where(
                        Expression<Func<Tenant, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Tenant, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Tenant>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tenant>();
                        }
                        else
                        {
                                return await this.Context.Set<Tenant>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Tenant>();
                        }
                }

                private async Task<Tenant> GetById(string id)
                {
                        List<Tenant> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>9595bccd208689a455c1a303edd4a52d</Hash>
</Codenesium>*/