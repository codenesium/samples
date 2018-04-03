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
	public abstract class AbstractPurchaseOrderHeaderRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPurchaseOrderHeaderRepository(ILogger logger,
		                                             ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int revisionNumber,
		                          int status,
		                          int employeeID,
		                          int vendorID,
		                          int shipMethodID,
		                          DateTime orderDate,
		                          Nullable<DateTime> shipDate,
		                          decimal subTotal,
		                          decimal taxAmt,
		                          decimal freight,
		                          decimal totalDue,
		                          DateTime modifiedDate)
		{
			var record = new EFPurchaseOrderHeader ();

			MapPOCOToEF(0, revisionNumber,
			            status,
			            employeeID,
			            vendorID,
			            shipMethodID,
			            orderDate,
			            shipDate,
			            subTotal,
			            taxAmt,
			            freight,
			            totalDue,
			            modifiedDate, record);

			this._context.Set<EFPurchaseOrderHeader>().Add(record);
			this._context.SaveChanges();
			return record.purchaseOrderID;
		}

		public virtual void Update(int purchaseOrderID, int revisionNumber,
		                           int status,
		                           int employeeID,
		                           int vendorID,
		                           int shipMethodID,
		                           DateTime orderDate,
		                           Nullable<DateTime> shipDate,
		                           decimal subTotal,
		                           decimal taxAmt,
		                           decimal freight,
		                           decimal totalDue,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.purchaseOrderID == purchaseOrderID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",purchaseOrderID);
			}
			else
			{
				MapPOCOToEF(purchaseOrderID,  revisionNumber,
				            status,
				            employeeID,
				            vendorID,
				            shipMethodID,
				            orderDate,
				            shipDate,
				            subTotal,
				            taxAmt,
				            freight,
				            totalDue,
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
				this._context.Set<EFPurchaseOrderHeader>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int purchaseOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.purchaseOrderID == purchaseOrderID,response);
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEF(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPurchaseOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPurchaseOrderHeader, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPurchaseOrderHeader> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int purchaseOrderID, int revisionNumber,
		                               int status,
		                               int employeeID,
		                               int vendorID,
		                               int shipMethodID,
		                               DateTime orderDate,
		                               Nullable<DateTime> shipDate,
		                               decimal subTotal,
		                               decimal taxAmt,
		                               decimal freight,
		                               decimal totalDue,
		                               DateTime modifiedDate, EFPurchaseOrderHeader   efPurchaseOrderHeader)
		{
			efPurchaseOrderHeader.purchaseOrderID = purchaseOrderID;
			efPurchaseOrderHeader.revisionNumber = revisionNumber;
			efPurchaseOrderHeader.status = status;
			efPurchaseOrderHeader.employeeID = employeeID;
			efPurchaseOrderHeader.vendorID = vendorID;
			efPurchaseOrderHeader.shipMethodID = shipMethodID;
			efPurchaseOrderHeader.orderDate = orderDate;
			efPurchaseOrderHeader.shipDate = shipDate;
			efPurchaseOrderHeader.subTotal = subTotal;
			efPurchaseOrderHeader.taxAmt = taxAmt;
			efPurchaseOrderHeader.freight = freight;
			efPurchaseOrderHeader.totalDue = totalDue;
			efPurchaseOrderHeader.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPurchaseOrderHeader efPurchaseOrderHeader,Response response)
		{
			if(efPurchaseOrderHeader == null)
			{
				return;
			}
			response.AddPurchaseOrderHeader(new POCOPurchaseOrderHeader()
			{
				PurchaseOrderID = efPurchaseOrderHeader.purchaseOrderID.ToInt(),
				RevisionNumber = efPurchaseOrderHeader.revisionNumber,
				Status = efPurchaseOrderHeader.status,
				EmployeeID = efPurchaseOrderHeader.employeeID.ToInt(),
				VendorID = efPurchaseOrderHeader.vendorID.ToInt(),
				ShipMethodID = efPurchaseOrderHeader.shipMethodID.ToInt(),
				OrderDate = efPurchaseOrderHeader.orderDate.ToDateTime(),
				ShipDate = efPurchaseOrderHeader.shipDate.ToNullableDateTime(),
				SubTotal = efPurchaseOrderHeader.subTotal,
				TaxAmt = efPurchaseOrderHeader.taxAmt,
				Freight = efPurchaseOrderHeader.freight,
				TotalDue = efPurchaseOrderHeader.totalDue,
				ModifiedDate = efPurchaseOrderHeader.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>19ffd4af51bf85e93139a3093dc3a31c</Hash>
</Codenesium>*/