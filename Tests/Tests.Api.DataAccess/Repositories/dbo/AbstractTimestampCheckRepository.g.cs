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

namespace TestsNS.Api.DataAccess
{
        public abstract class AbstractTimestampCheckRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTimestampCheckRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TimestampCheck>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<TimestampCheck> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<TimestampCheck> Create(TimestampCheck item)
                {
                        this.Context.Set<TimestampCheck>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TimestampCheck item)
                {
                        var entity = this.Context.Set<TimestampCheck>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<TimestampCheck>().Attach(item);
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
                        TimestampCheck record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TimestampCheck>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<TimestampCheck>> Where(
                        Expression<Func<TimestampCheck, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<TimestampCheck, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<TimestampCheck>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TimestampCheck>();
                        }
                        else
                        {
                                return await this.Context.Set<TimestampCheck>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TimestampCheck>();
                        }
                }

                private async Task<TimestampCheck> GetById(int id)
                {
                        List<TimestampCheck> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>98e9ffefec56b1dc664392e0618619de</Hash>
</Codenesium>*/