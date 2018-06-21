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

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractErrorLogRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractErrorLogRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<ErrorLog> Get(int errorLogID)
                {
                        return await this.GetById(errorLogID);
                }

                public async virtual Task<ErrorLog> Create(ErrorLog item)
                {
                        this.Context.Set<ErrorLog>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ErrorLog item)
                {
                        var entity = this.Context.Set<ErrorLog>().Local.FirstOrDefault(x => x.ErrorLogID == item.ErrorLogID);
                        if (entity == null)
                        {
                                this.Context.Set<ErrorLog>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int errorLogID)
                {
                        ErrorLog record = await this.GetById(errorLogID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ErrorLog>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ErrorLog>> Where(
                        Expression<Func<ErrorLog, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ErrorLog, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.ErrorLogID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ErrorLog>();
                        }
                        else
                        {
                                return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ErrorLog>();
                        }
                }

                private async Task<ErrorLog> GetById(int errorLogID)
                {
                        List<ErrorLog> records = await this.Where(x => x.ErrorLogID == errorLogID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>259889adfc51051affdf19421efe8cff</Hash>
</Codenesium>*/