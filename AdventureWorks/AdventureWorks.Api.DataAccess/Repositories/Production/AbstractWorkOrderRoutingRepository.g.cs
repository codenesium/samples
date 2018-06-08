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
        public abstract class AbstractWorkOrderRoutingRepository: AbstractRepository
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

                public virtual Task<List<WorkOrderRouting>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<WorkOrderRouting>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }

                protected async Task<List<WorkOrderRouting>> Where(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<WorkOrderRouting> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<WorkOrderRouting>> SearchLinqEF(Expression<Func<WorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
                        }

                        return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrderRouting>();
                }

                private async Task<List<WorkOrderRouting>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkOrderRouting.WorkOrderID)} ASC";
                        }

                        return await this.Context.Set<WorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrderRouting>();
                }

                private async Task<WorkOrderRouting> GetById(int workOrderID)
                {
                        List<WorkOrderRouting> records = await this.SearchLinqEF(x => x.WorkOrderID == workOrderID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>d87e08735584bbcfccb1c972c3e5584b</Hash>
</Codenesium>*/