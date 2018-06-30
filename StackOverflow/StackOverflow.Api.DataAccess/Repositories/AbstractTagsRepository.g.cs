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

namespace StackOverflowNS.Api.DataAccess
{
        public abstract class AbstractTagsRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTagsRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Tags> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Tags> Create(Tags item)
                {
                        this.Context.Set<Tags>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Tags item)
                {
                        var entity = this.Context.Set<Tags>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Tags>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        Tags record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Tags>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Tags>> Where(
                        Expression<Func<Tags, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Tags, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Tags>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tags>();
                        }
                        else
                        {
                                return await this.Context.Set<Tags>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Tags>();
                        }
                }

                private async Task<Tags> GetById(int id)
                {
                        List<Tags> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>8607e4bd9c8a89584ca45fd84e3e46d1</Hash>
</Codenesium>*/