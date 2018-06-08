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

                public virtual Task<List<DatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                protected async Task<List<DatabaseLog>> Where(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<DatabaseLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<DatabaseLog>> SearchLinqEF(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
                        }

                        return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DatabaseLog>();
                }

                private async Task<List<DatabaseLog>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
                        }

                        return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DatabaseLog>();
                }

                private async Task<DatabaseLog> GetById(int databaseLogID)
                {
                        List<DatabaseLog> records = await this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b87524c70f607be7baf722843e566741</Hash>
</Codenesium>*/