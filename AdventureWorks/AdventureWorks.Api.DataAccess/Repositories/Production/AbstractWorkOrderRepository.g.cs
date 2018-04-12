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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractWorkOrderRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate)
		{
			var record = new EFWorkOrder();

			MapPOCOToEF(
				0,
				productID,
				orderQty,
				stockedQty,
				scrappedQty,
				startDate,
				endDate,
				dueDate,
				scrapReasonID,
				modifiedDate,
				record);

			this.context.Set<EFWorkOrder>().Add(record);
			this.context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(
			int workOrderID,
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{workOrderID}");
			}
			else
			{
				MapPOCOToEF(
					workOrderID,
					productID,
					orderQty,
					stockedQty,
					scrappedQty,
					startDate,
					endDate,
					dueDate,
					scrapReasonID,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFWorkOrder>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int workOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response;
		}

		public virtual POCOWorkOrder GetByIdDirect(int workOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response.WorkOrders.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOWorkOrder> GetWhereDirect(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.WorkOrders;
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrder, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrder> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrder> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFWorkOrder> SearchLinqEF(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrder> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int workOrderID,
			int productID,
			int orderQty,
			int stockedQty,
			short scrappedQty,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime dueDate,
			Nullable<short> scrapReasonID,
			DateTime modifiedDate,
			EFWorkOrder efWorkOrder)
		{
			efWorkOrder.SetProperties(workOrderID.ToInt(), productID.ToInt(), orderQty.ToInt(), stockedQty.ToInt(), scrappedQty, startDate.ToDateTime(), endDate.ToNullableDateTime(), dueDate.ToDateTime(), scrapReasonID, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFWorkOrder efWorkOrder,
			Response response)
		{
			if (efWorkOrder == null)
			{
				return;
			}

			response.AddWorkOrder(new POCOWorkOrder(efWorkOrder.WorkOrderID.ToInt(), efWorkOrder.ProductID.ToInt(), efWorkOrder.OrderQty.ToInt(), efWorkOrder.StockedQty.ToInt(), efWorkOrder.ScrappedQty, efWorkOrder.StartDate.ToDateTime(), efWorkOrder.EndDate.ToNullableDateTime(), efWorkOrder.DueDate.ToDateTime(), efWorkOrder.ScrapReasonID, efWorkOrder.ModifiedDate.ToDateTime()));

			ProductRepository.MapEFToPOCO(efWorkOrder.Product, response);

			ScrapReasonRepository.MapEFToPOCO(efWorkOrder.ScrapReason, response);
		}
	}
}

/*<Codenesium>
    <Hash>573e2ea25ee64bf2c4a576d378ed50ac</Hash>
</Codenesium>*/