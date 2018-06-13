using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractWorkerPoolRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractWorkerPoolRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<WorkerPool>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<WorkerPool> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<WorkerPool> Create(WorkerPool item)
                {
                        this.Context.Set<WorkerPool>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(WorkerPool item)
                {
                        var entity = this.Context.Set<WorkerPool>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<WorkerPool>().Attach(item);
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
                        WorkerPool record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<WorkerPool>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<WorkerPool> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<WorkerPool>> Where(Expression<Func<WorkerPool, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<WorkerPool> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<WorkerPool>> SearchLinqEF(Expression<Func<WorkerPool, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkerPool.Id)} ASC";
                        }

                        return await this.Context.Set<WorkerPool>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkerPool>();
                }

                private async Task<List<WorkerPool>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkerPool.Id)} ASC";
                        }

                        return await this.Context.Set<WorkerPool>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkerPool>();
                }

                private async Task<WorkerPool> GetById(string id)
                {
                        List<WorkerPool> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>dfeb958b2fe04e3383dd6f58a4778c65</Hash>
</Codenesium>*/