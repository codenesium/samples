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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractWorkOrderRepository(ILogger logger,
		                                   ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int productID,
		                          int orderQty,
		                          int stockedQty,
		                          short scrappedQty,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          DateTime dueDate,
		                          Nullable<short> scrapReasonID,
		                          DateTime modifiedDate)
		{
			var record = new EFWorkOrder ();

			MapPOCOToEF(0, productID,
			            orderQty,
			            stockedQty,
			            scrappedQty,
			            startDate,
			            endDate,
			            dueDate,
			            scrapReasonID,
			            modifiedDate, record);

			this._context.Set<EFWorkOrder>().Add(record);
			this._context.SaveChanges();
			return record.workOrderID;
		}

		public virtual void Update(int workOrderID, int productID,
		                           int orderQty,
		                           int stockedQty,
		                           short scrappedQty,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           DateTime dueDate,
		                           Nullable<short> scrapReasonID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.workOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",workOrderID);
			}
			else
			{
				MapPOCOToEF(workOrderID,  productID,
				            orderQty,
				            stockedQty,
				            scrappedQty,
				            startDate,
				            endDate,
				            dueDate,
				            scrapReasonID,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.workOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFWorkOrder>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int workOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.workOrderID == workOrderID,response);
		}

		protected virtual List<EFWorkOrder> SearchLinqEF(Expression<Func<EFWorkOrder, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrder> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFWorkOrder, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrder, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrder> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFWorkOrder> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int workOrderID, int productID,
		                               int orderQty,
		                               int stockedQty,
		                               short scrappedQty,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               DateTime dueDate,
		                               Nullable<short> scrapReasonID,
		                               DateTime modifiedDate, EFWorkOrder   efWorkOrder)
		{
			efWorkOrder.workOrderID = workOrderID;
			efWorkOrder.productID = productID;
			efWorkOrder.orderQty = orderQty;
			efWorkOrder.stockedQty = stockedQty;
			efWorkOrder.scrappedQty = scrappedQty;
			efWorkOrder.startDate = startDate;
			efWorkOrder.endDate = endDate;
			efWorkOrder.dueDate = dueDate;
			efWorkOrder.scrapReasonID = scrapReasonID;
			efWorkOrder.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFWorkOrder efWorkOrder,Response response)
		{
			if(efWorkOrder == null)
			{
				return;
			}
			response.AddWorkOrder(new POCOWorkOrder()
			{
				WorkOrderID = efWorkOrder.workOrderID.ToInt(),
				ProductID = efWorkOrder.productID.ToInt(),
				OrderQty = efWorkOrder.orderQty.ToInt(),
				StockedQty = efWorkOrder.stockedQty.ToInt(),
				ScrappedQty = efWorkOrder.scrappedQty,
				StartDate = efWorkOrder.startDate.ToDateTime(),
				EndDate = efWorkOrder.endDate.ToNullableDateTime(),
				DueDate = efWorkOrder.dueDate.ToDateTime(),
				ScrapReasonID = efWorkOrder.scrapReasonID,
				ModifiedDate = efWorkOrder.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>94ac4d172bf122a11f7d05b5f1486598</Hash>
</Codenesium>*/