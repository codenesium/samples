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
        public abstract class AbstractActionTemplateVersionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractActionTemplateVersionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ActionTemplateVersion>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<ActionTemplateVersion> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ActionTemplateVersion> Create(ActionTemplateVersion item)
                {
                        this.Context.Set<ActionTemplateVersion>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ActionTemplateVersion item)
                {
                        var entity = this.Context.Set<ActionTemplateVersion>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ActionTemplateVersion>().Attach(item);
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
                        ActionTemplateVersion record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ActionTemplateVersion>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ActionTemplateVersion> GetNameVersion(string name, int version)
                {
                        var records = await this.Where(x => x.Name == name && x.Version == version);

                        return records.FirstOrDefault();
                }
                public async Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId)
                {
                        var records = await this.Where(x => x.LatestActionTemplateId == latestActionTemplateId);

                        return records;
                }

                protected async Task<List<ActionTemplateVersion>> Where(
                        Expression<Func<ActionTemplateVersion, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ActionTemplateVersion, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ActionTemplateVersion>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ActionTemplateVersion>();
                        }
                        else
                        {
                                return await this.Context.Set<ActionTemplateVersion>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ActionTemplateVersion>();
                        }
                }

                private async Task<ActionTemplateVersion> GetById(string id)
                {
                        List<ActionTemplateVersion> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>7e28b71b03f18cef2dc234f0fe797002</Hash>
</Codenesium>*/