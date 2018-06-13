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
        public abstract class AbstractWorkOrderRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractWorkOrderRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<WorkOrder> Get(int workOrderID)
                {
                        return await this.GetById(workOrderID);
                }

                public async virtual Task<WorkOrder> Create(WorkOrder item)
                {
                        this.Context.Set<WorkOrder>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(WorkOrder item)
                {
                        var entity = this.Context.Set<WorkOrder>().Local.FirstOrDefault(x => x.WorkOrderID == item.WorkOrderID);
                        if (entity == null)
                        {
                                this.Context.Set<WorkOrder>().Attach(item);
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
                        WorkOrder record = await this.GetById(workOrderID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<WorkOrder>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<WorkOrder>> GetProductID(int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records;
                }
                public async Task<List<WorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID)
                {
                        var records = await this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID);

                        return records;
                }

                protected async Task<List<WorkOrder>> Where(Expression<Func<WorkOrder, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<WorkOrder> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<WorkOrder>> SearchLinqEF(Expression<Func<WorkOrder, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
                        }

                        return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkOrder>();
                }

                private async Task<List<WorkOrder>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
                        }

                        return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<WorkOrder>();
                }

                private async Task<WorkOrder> GetById(int workOrderID)
                {
                        List<WorkOrder> records = await this.SearchLinqEF(x => x.WorkOrderID == workOrderID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<WorkOrderRouting>> WorkOrderRoutings(int workOrderID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<WorkOrderRouting>().Where(x => x.WorkOrderID == workOrderID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrderRouting>();
                }
        }
}

/*<Codenesium>
    <Hash>bfc07bd9c2e5e38c4484976334dfcbae</Hash>
</Codenesium>*/