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

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractWorkerTaskLeaseRepository : AbstractRepository
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

                public virtual Task<List<WorkerTaskLease>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                protected async Task<List<WorkerTaskLease>> Where(
                        Expression<Func<WorkerTaskLease, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<WorkerTaskLease, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<WorkerTaskLease>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<WorkerTaskLease>();
                        }
                        else
                        {
                                return await this.Context.Set<WorkerTaskLease>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<WorkerTaskLease>();
                        }
                }

                private async Task<WorkerTaskLease> GetById(string id)
                {
                        List<WorkerTaskLease> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4838f32962637b2426c95e71b84a1550</Hash>
</Codenesium>*/