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
        public abstract class AbstractDatabaseLogRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDatabaseLogRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<DatabaseLog> Get(int databaseLogID)
                {
                        return await this.GetById(databaseLogID);
                }

                public async virtual Task<DatabaseLog> Create(DatabaseLog item)
                {
                        this.Context.Set<DatabaseLog>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DatabaseLog item)
                {
                        var entity = this.Context.Set<DatabaseLog>().Local.FirstOrDefault(x => x.DatabaseLogID == item.DatabaseLogID);
                        if (entity == null)
                        {
                                this.Context.Set<DatabaseLog>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int databaseLogID)
                {
                        DatabaseLog record = await this.GetById(databaseLogID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DatabaseLog>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<DatabaseLog>> Where(Expression<Func<DatabaseLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<DatabaseLog> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<DatabaseLog>> SearchLinqEF(Expression<Func<DatabaseLog, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
                        }

                        return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DatabaseLog>();
                }

                private async Task<List<DatabaseLog>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
                        }

                        return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<DatabaseLog>();
                }

                private async Task<DatabaseLog> GetById(int databaseLogID)
                {
                        List<DatabaseLog> records = await this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ba8ddbdc355e1a3035c86013bc507f12</Hash>
</Codenesium>*/