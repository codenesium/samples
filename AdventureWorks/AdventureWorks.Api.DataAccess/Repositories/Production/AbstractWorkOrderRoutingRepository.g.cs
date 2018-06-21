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
        public abstract class AbstractWorkOrderRoutingRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractWorkOrderRoutingRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<WorkOrderRouting>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<WorkOrderRouting> Get(int workOrderID)
                {
                        return await this.GetById(workOrderID);
                }

                public async virtual Task<WorkOrderRouting> Create(WorkOrderRouting item)
                {
                        this.Context.Set<WorkOrderRouting>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(WorkOrderRouting item)
                {
                        var entity = this.Context.Set<WorkOrderRouting>().Local.FirstOrDefault(x => x.WorkOrderID == item.WorkOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<WorkOrderRouting>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int workOrderID)
                {
                        WorkOrderRouting record = await this.GetById(workOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<WorkOrderRouting>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<WorkOrderRouting>> ByProductID(int productID)
                {
                        var records = await this.Where(x => x.ProductID == productID);

                        return records;
                }

                protected async Task<List<WorkOrderRouting>> Where(
                        Expression<Func<WorkOrderRouting, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<WorkOrderRouting, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.WorkOrderID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<WorkOrderRouting>();
                        }
                        else
                        {
                                return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<WorkOrderRouting>();
                        }
                }

                private async Task<WorkOrderRouting> GetById(int workOrderID)
                {
                        List<WorkOrderRouting> records = await this.Where(x => x.WorkOrderID == workOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>b3a08b62c3b9faa764d23416cc39759c</Hash>
</Codenesium>*/