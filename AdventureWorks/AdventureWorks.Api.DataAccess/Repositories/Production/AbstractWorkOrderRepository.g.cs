using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractWorkOrderRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractWorkOrderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOWorkOrder> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOWorkOrder Get(int workOrderID)
		{
			return this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID).FirstOrDefault();
		}

		public virtual POCOWorkOrder Create(
			ApiWorkOrderModel model)
		{
			WorkOrder record = new WorkOrder();

			this.Mapper.WorkOrderMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<WorkOrder>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.WorkOrderMapEFToPOCO(record);
		}

		public virtual void Update(
			int workOrderID,
			ApiWorkOrderModel model)
		{
			WorkOrder record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			WorkOrder record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<WorkOrder>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOWorkOrder> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}
		public List<POCOWorkOrder> GetScrapReasonID(Nullable<short> scrapReasonID)
		{
			return this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID);
		}

		protected List<POCOWorkOrder> Where(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOWorkOrder> SearchLinqPOCO(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOWorkOrder> response = new List<POCOWorkOrder>();
			List<WorkOrder> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.WorkOrderMapEFToPOCO(x)));
			return response;
		}

		private List<WorkOrder> SearchLinqEF(Expression<Func<WorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}
			return this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<WorkOrder>();
		}

		private List<WorkOrder> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(WorkOrder.WorkOrderID)} ASC";
			}

			return this.Context.Set<WorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<WorkOrder>();
		}
	}
}

/*<Codenesium>
    <Hash>4cf211ae064ade6d9af844b9815feee0</Hash>
</Codenesium>*/