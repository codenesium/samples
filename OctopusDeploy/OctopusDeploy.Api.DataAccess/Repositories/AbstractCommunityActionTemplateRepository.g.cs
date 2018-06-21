using Codenesium.DataConversionExtensions;
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
        public abstract class AbstractCommunityActionTemplateRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCommunityActionTemplateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<CommunityActionTemplate>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<CommunityActionTemplate> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<CommunityActionTemplate> Create(CommunityActionTemplate item)
                {
                        this.Context.Set<CommunityActionTemplate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(CommunityActionTemplate item)
                {
                        var entity = this.Context.Set<CommunityActionTemplate>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<CommunityActionTemplate>().Attach(item);
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
                        CommunityActionTemplate record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<CommunityActionTemplate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<CommunityActionTemplate> GetExternalId(Guid externalId)
                {
                        var records = await this.Where(x => x.ExternalId == externalId);

                        return records.FirstOrDefault();
                }

                public async Task<CommunityActionTemplate> GetName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<CommunityActionTemplate>> Where(
                        Expression<Func<CommunityActionTemplate, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<CommunityActionTemplate, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<CommunityActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CommunityActionTemplate>();
                        }
                        else
                        {
                                return await this.Context.Set<CommunityActionTemplate>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<CommunityActionTemplate>();
                        }
                }

                private async Task<CommunityActionTemplate> GetById(string id)
                {
                        List<CommunityActionTemplate> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b5aa51861f56185bff30517b77df9b26</Hash>
</Codenesium>*/