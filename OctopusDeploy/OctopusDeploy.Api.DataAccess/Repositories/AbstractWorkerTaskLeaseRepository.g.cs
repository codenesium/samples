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
        public abstract class AbstractWorkerTaskLeaseRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractWorkerTaskLeaseRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<WorkerTaskLease> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<WorkerTaskLease> Create(WorkerTaskLease item)
                {
                        this.Context.Set<WorkerTaskLease>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(WorkerTaskLease item)
                {
                        var entity = this.Context.Set<WorkerTaskLease>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<WorkerTaskLease>().Attach(item);
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
                        WorkerTaskLease record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<WorkerTaskLease>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<WorkerTaskLease>> Where(Expression<Func<WorkerTaskLease, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<WorkerTaskLease> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<WorkerTaskLease>> SearchLinqEF(Expression<Func<WorkerTaskLease, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkerTaskLease.Id)} ASC";
                        }

                        return await this.Context.Set<WorkerTaskLease>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkerTaskLease>();
                }

                private async Task<List<WorkerTaskLease>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkerTaskLease.Id)} ASC";
                        }

                        return await this.Context.Set<WorkerTaskLease>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkerTaskLease>();
                }

                private async Task<WorkerTaskLease> GetById(string id)
                {
                        List<WorkerTaskLease> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b30fe9855aa921e7c2dbfd1df1d2a055</Hash>
</Codenesium>*/