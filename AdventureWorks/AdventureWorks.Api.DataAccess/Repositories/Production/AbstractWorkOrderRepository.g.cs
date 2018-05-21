using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractWorkOrderRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractWorkOrderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOWorkOrder>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOWorkOrder> Get(int workOrderID)
		{
			WorkOrder record = await this.GetById(workOrderID);

			return this.Mapper.WorkOrderMapEFToPOCO(record);
		}

		public async virtual Task<POCOWorkOrder> Create(
			ApiWorkOrderModel model)
		{
			WorkOrder record = new WorkOrder();

			this.Mapper.WorkOrderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<WorkOrder>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.WorkOrderMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int workOrderID,
			ApiWorkOrderModel model)
		{
			WorkOrder record = await this.GetById(workOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.Mapper.WorkOrderMapModelToEF(
					workOrderID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		public async Task<List<POCOWorkOrder>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}
		public async Task<List<POCOWorkOrder>> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			var records = await this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID);

			return records;
		}

		protected async Task<List<POCOWorkOrder>> Where(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrder> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOWorkOrder>> SearchLinqPOCO(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrder> response = new List<POCOWorkOrder>();
			List<WorkOrder> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.WorkOrderMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<WorkOrder>> SearchLinqEF(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}
			return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrder>();
		}

		private async Task<List<WorkOrder>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}

			return await this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<WorkOrder>();
		}

		private async Task<WorkOrder> GetById(int workOrderID)
		{
			List<WorkOrder> records = await this.SearchLinqEF(x => x.WorkOrderID == workOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fb6418ab44ce2f2fe0e6b8d071fd7e95</Hash>
</Codenesium>*/