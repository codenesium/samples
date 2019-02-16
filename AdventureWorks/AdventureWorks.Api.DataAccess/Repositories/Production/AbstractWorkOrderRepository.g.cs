using Codenesium.DataConversionExtensions;
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
	public abstract class AbstractWorkOrderRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractWorkOrderRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<WorkOrder>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.DueDate == query.ToDateTime() ||
				                  x.EndDate == query.ToNullableDateTime() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.OrderQty == query.ToInt() ||
				                  x.ProductID == query.ToInt() ||
				                  x.ScrappedQty == query.ToShort() ||
				                  x.ScrapReasonID == query.ToNullableShort() ||
				                  x.StartDate == query.ToDateTime() ||
				                  x.StockedQty == query.ToInt() ||
				                  x.WorkOrderID == query.ToInt(),
				                  limit,
				                  offset);
			}
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

		// Non-unique constraint IX_WorkOrder_ProductID.
		public async virtual Task<List<WorkOrder>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ProductID == productID, limit, offset);
		}

		// Non-unique constraint IX_WorkOrder_ScrapReasonID.
		public async virtual Task<List<WorkOrder>> ByScrapReasonID(short? scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ScrapReasonID == scrapReasonID, limit, offset);
		}

		protected async Task<List<WorkOrder>> Where(
			Expression<Func<WorkOrder, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<WorkOrder, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.WorkOrderID;
			}

			return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<WorkOrder>();
		}

		private async Task<WorkOrder> GetById(int workOrderID)
		{
			List<WorkOrder> records = await this.Where(x => x.WorkOrderID == workOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>693b3619301d8bd772ca3f648c340a01</Hash>
</Codenesium>*/