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
        public abstract class AbstractTagSetRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTagSetRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TagSet>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<TagSet> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TagSet> Create(TagSet item)
                {
                        this.Context.Set<TagSet>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TagSet item)
                {
                        var entity = this.Context.Set<TagSet>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TagSet>().Attach(item);
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
                        TagSet record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TagSet>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<TagSet> GetName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<List<TagSet>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.Where(x => x.DataVersion == dataVersion);

                        return records;
                }

                protected async Task<List<TagSet>> Where(
                        Expression<Func<TagSet, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<TagSet, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<TagSet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TagSet>();
                        }
                        else
                        {
                                return await this.Context.Set<TagSet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TagSet>();
                        }
                }

                private async Task<TagSet> GetById(string id)
                {
                        List<TagSet> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f3afcab813d1672edd8bc4962688e7d8</Hash>
</Codenesium>*/