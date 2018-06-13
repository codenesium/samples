using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractErrorLogRepository: AbstractRepository
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

                public virtual Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<ErrorLog>> Where(Expression<Func<ErrorLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ErrorLog> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ErrorLog>> SearchLinqEF(Expression<Func<ErrorLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
                        }

                        return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ErrorLog>();
                }

                private async Task<List<ErrorLog>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
                        }

                        return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ErrorLog>();
                }

                private async Task<ErrorLog> GetById(int errorLogID)
                {
                        List<ErrorLog> records = await this.SearchLinqEF(x => x.ErrorLogID == errorLogID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4a2a9ece03ca8241cceb3563031cb4b7</Hash>
</Codenesium>*/