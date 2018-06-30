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
        public abstract class AbstractPostLinksRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPostLinksRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<PostLinks> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<PostLinks> Create(PostLinks item)
                {
                        this.Context.Set<PostLinks>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(PostLinks item)
                {
                        var entity = this.Context.Set<PostLinks>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<PostLinks>().Attach(item);
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
                        PostLinks record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<PostLinks>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<PostLinks>> Where(
                        Expression<Func<PostLinks, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<PostLinks, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<PostLinks>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PostLinks>();
                        }
                        else
                        {
                                return await this.Context.Set<PostLinks>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PostLinks>();
                        }
                }

                private async Task<PostLinks> GetById(int id)
                {
                        List<PostLinks> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>56c2fa7263fe82315aa7c710d1cf7f71</Hash>
</Codenesium>*/