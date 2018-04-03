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
	public abstract class AbstractSalesOrderDetailRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesOrderDetailRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int salesOrderDetailID,
		                          string carrierTrackingNumber,
		                          short orderQty,
		                          int productID,
		                          int specialOfferID,
		                          decimal unitPrice,
		                          decimal unitPriceDiscount,
		                          decimal lineTotal,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesOrderDetail ();

			MapPOCOToEF(0, salesOrderDetailID,
			            carrierTrackingNumber,
			            orderQty,
			            productID,
			            specialOfferID,
			            unitPrice,
			            unitPriceDiscount,
			            lineTotal,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesOrderDetail>().Add(record);
			this._context.SaveChanges();
			return record.salesOrderID;
		}

		public virtual void Update(int salesOrderID, int salesOrderDetailID,
		                           string carrierTrackingNumber,
		                           short orderQty,
		                           int productID,
		                           int specialOfferID,
		                           decimal unitPrice,
		                           decimal unitPriceDiscount,
		                           decimal lineTotal,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.salesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",salesOrderID);
			}
			else
			{
				MapPOCOToEF(salesOrderID,  salesOrderDetailID,
				            carrierTrackingNumber,
				            orderQty,
				            productID,
				            specialOfferID,
				            unitPrice,
				            unitPriceDiscount,
				            lineTotal,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.salesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesOrderDetail>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.salesOrderID == salesOrderID,response);
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEF(Expression<Func<EFSalesOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderDetail, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesOrderID, int salesOrderDetailID,
		                               string carrierTrackingNumber,
		                               short orderQty,
		                               int productID,
		                               int specialOfferID,
		                               decimal unitPrice,
		                               decimal unitPriceDiscount,
		                               decimal lineTotal,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesOrderDetail   efSalesOrderDetail)
		{
			efSalesOrderDetail.salesOrderID = salesOrderID;
			efSalesOrderDetail.salesOrderDetailID = salesOrderDetailID;
			efSalesOrderDetail.carrierTrackingNumber = carrierTrackingNumber;
			efSalesOrderDetail.orderQty = orderQty;
			efSalesOrderDetail.productID = productID;
			efSalesOrderDetail.specialOfferID = specialOfferID;
			efSalesOrderDetail.unitPrice = unitPrice;
			efSalesOrderDetail.unitPriceDiscount = unitPriceDiscount;
			efSalesOrderDetail.lineTotal = lineTotal;
			efSalesOrderDetail.rowguid = rowguid;
			efSalesOrderDetail.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesOrderDetail efSalesOrderDetail,Response response)
		{
			if(efSalesOrderDetail == null)
			{
				return;
			}
			response.AddSalesOrderDetail(new POCOSalesOrderDetail()
			{
				SalesOrderID = efSalesOrderDetail.salesOrderID.ToInt(),
				SalesOrderDetailID = efSalesOrderDetail.salesOrderDetailID.ToInt(),
				CarrierTrackingNumber = efSalesOrderDetail.carrierTrackingNumber,
				OrderQty = efSalesOrderDetail.orderQty,
				ProductID = efSalesOrderDetail.productID.ToInt(),
				SpecialOfferID = efSalesOrderDetail.specialOfferID.ToInt(),
				UnitPrice = efSalesOrderDetail.unitPrice,
				UnitPriceDiscount = efSalesOrderDetail.unitPriceDiscount,
				LineTotal = efSalesOrderDetail.lineTotal.ToDecimal(),
				Rowguid = efSalesOrderDetail.rowguid,
				ModifiedDate = efSalesOrderDetail.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>4f9fa5768844c6d480c2335c520ead2b</Hash>
</Codenesium>*/