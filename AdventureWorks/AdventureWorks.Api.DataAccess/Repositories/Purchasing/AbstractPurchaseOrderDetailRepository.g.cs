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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPurchaseOrderDetailRepository(ILogger logger,
		                                             ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFPurchaseOrderDetail>().Add(record);
			this.context.SaveChanges();
			return record.PurchaseOrderID;
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
			var record =  this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",purchaseOrderID);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int purchaseOrderID)
		{
			var record = this.SearchLinqEF(x => x.PurchaseOrderID == purchaseOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFPurchaseOrderDetail>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int purchaseOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID,response);
			return response;
		}

		public virtual POCOPurchaseOrderDetail GetByIdDirect(int purchaseOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.PurchaseOrderID == purchaseOrderID,response);
			return response.PurchaseOrderDetails.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPurchaseOrderDetail> GetWhereDirect(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PurchaseOrderDetails;
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

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efPurchaseOrderDetail.PurchaseOrderID = purchaseOrderID;
			efPurchaseOrderDetail.PurchaseOrderDetailID = purchaseOrderDetailID;
			efPurchaseOrderDetail.DueDate = dueDate;
			efPurchaseOrderDetail.OrderQty = orderQty;
			efPurchaseOrderDetail.ProductID = productID;
			efPurchaseOrderDetail.UnitPrice = unitPrice;
			efPurchaseOrderDetail.LineTotal = lineTotal;
			efPurchaseOrderDetail.ReceivedQty = receivedQty;
			efPurchaseOrderDetail.RejectedQty = rejectedQty;
			efPurchaseOrderDetail.StockedQty = stockedQty;
			efPurchaseOrderDetail.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPurchaseOrderDetail efPurchaseOrderDetail,Response response)
		{
			if(efPurchaseOrderDetail == null)
			{
				return;
			}
			response.AddPurchaseOrderDetail(new POCOPurchaseOrderDetail()
			{
				PurchaseOrderDetailID = efPurchaseOrderDetail.PurchaseOrderDetailID.ToInt(),
				DueDate = efPurchaseOrderDetail.DueDate.ToDateTime(),
				OrderQty = efPurchaseOrderDetail.OrderQty,
				UnitPrice = efPurchaseOrderDetail.UnitPrice,
				LineTotal = efPurchaseOrderDetail.LineTotal,
				ReceivedQty = efPurchaseOrderDetail.ReceivedQty.ToDecimal(),
				RejectedQty = efPurchaseOrderDetail.RejectedQty.ToDecimal(),
				StockedQty = efPurchaseOrderDetail.StockedQty.ToDecimal(),
				ModifiedDate = efPurchaseOrderDetail.ModifiedDate.ToDateTime(),

				PurchaseOrderID = new ReferenceEntity<int>(efPurchaseOrderDetail.PurchaseOrderID,
				                                           "PurchaseOrderHeaders"),
				ProductID = new ReferenceEntity<int>(efPurchaseOrderDetail.ProductID,
				                                     "Products"),
			});

			PurchaseOrderHeaderRepository.MapEFToPOCO(efPurchaseOrderDetail.PurchaseOrderHeader, response);

			ProductRepository.MapEFToPOCO(efPurchaseOrderDetail.Product, response);
		}
	}
}

/*<Codenesium>
    <Hash>72c0b2f76e139300122aab519513b8c7</Hash>
</Codenesium>*/