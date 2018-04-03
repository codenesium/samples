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
	public abstract class AbstractPurchaseOrderDetailRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPurchaseOrderDetailRepository(ILogger logger,
		                                             ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int purchaseOrderDetailID,
		                          DateTime dueDate,
		                          short orderQty,
		                          int productID,
		                          decimal unitPrice,
		                          decimal lineTotal,
		                          decimal receivedQty,
		                          decimal rejectedQty,
		                          decimal stockedQty,
		                          DateTime modifiedDate)
		{
			var record = new EFPurchaseOrderDetail ();

			MapPOCOToEF(0, purchaseOrderDetailID,
			            dueDate,
			            orderQty,
			            productID,
			            unitPrice,
			            lineTotal,
			            receivedQty,
			            rejectedQty,
			            stockedQty,
			            modifiedDate, record);

			this._context.Set<EFPurchaseOrderDetail>().Add(record);
			this._context.SaveChanges();
			return record.purchaseOrderID;
		}

		public virtual void Update(int purchaseOrderID, int purchaseOrderDetailID,
		                           DateTime dueDate,
		                           short orderQty,
		                           int productID,
		                           decimal unitPrice,
		                           decimal lineTotal,
		                           decimal receivedQty,
		                           decimal rejectedQty,
		                           decimal stockedQty,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.purchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",purchaseOrderID);
			}
			else
			{
				MapPOCOToEF(purchaseOrderID,  purchaseOrderDetailID,
				            dueDate,
				            orderQty,
				            productID,
				            unitPrice,
				            lineTotal,
				            receivedQty,
				            rejectedQty,
				            stockedQty,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int purchaseOrderID)
		{
			var record = this.SearchLinqEF(x => x.purchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFPurchaseOrderDetail>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int purchaseOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.purchaseOrderID == purchaseOrderID,response);
		}

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFPurchaseOrderDetail, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderDetail> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderDetail> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int purchaseOrderID, int purchaseOrderDetailID,
		                               DateTime dueDate,
		                               short orderQty,
		                               int productID,
		                               decimal unitPrice,
		                               decimal lineTotal,
		                               decimal receivedQty,
		                               decimal rejectedQty,
		                               decimal stockedQty,
		                               DateTime modifiedDate, EFPurchaseOrderDetail   efPurchaseOrderDetail)
		{
			efPurchaseOrderDetail.purchaseOrderID = purchaseOrderID;
			efPurchaseOrderDetail.purchaseOrderDetailID = purchaseOrderDetailID;
			efPurchaseOrderDetail.dueDate = dueDate;
			efPurchaseOrderDetail.orderQty = orderQty;
			efPurchaseOrderDetail.productID = productID;
			efPurchaseOrderDetail.unitPrice = unitPrice;
			efPurchaseOrderDetail.lineTotal = lineTotal;
			efPurchaseOrderDetail.receivedQty = receivedQty;
			efPurchaseOrderDetail.rejectedQty = rejectedQty;
			efPurchaseOrderDetail.stockedQty = stockedQty;
			efPurchaseOrderDetail.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPurchaseOrderDetail efPurchaseOrderDetail,Response response)
		{
			if(efPurchaseOrderDetail == null)
			{
				return;
			}
			response.AddPurchaseOrderDetail(new POCOPurchaseOrderDetail()
			{
				PurchaseOrderID = efPurchaseOrderDetail.purchaseOrderID.ToInt(),
				PurchaseOrderDetailID = efPurchaseOrderDetail.purchaseOrderDetailID.ToInt(),
				DueDate = efPurchaseOrderDetail.dueDate.ToDateTime(),
				OrderQty = efPurchaseOrderDetail.orderQty,
				ProductID = efPurchaseOrderDetail.productID.ToInt(),
				UnitPrice = efPurchaseOrderDetail.unitPrice,
				LineTotal = efPurchaseOrderDetail.lineTotal,
				ReceivedQty = efPurchaseOrderDetail.receivedQty.ToDecimal(),
				RejectedQty = efPurchaseOrderDetail.rejectedQty.ToDecimal(),
				StockedQty = efPurchaseOrderDetail.stockedQty.ToDecimal(),
				ModifiedDate = efPurchaseOrderDetail.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>8da84230821b3631ef827e23f0e45787</Hash>
</Codenesium>*/