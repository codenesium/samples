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
	public abstract class AbstractSalesOrderHeaderRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesOrderHeaderRepository(ILogger logger,
		                                          ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int revisionNumber,
		                          DateTime orderDate,
		                          DateTime dueDate,
		                          Nullable<DateTime> shipDate,
		                          int status,
		                          bool onlineOrderFlag,
		                          string salesOrderNumber,
		                          string purchaseOrderNumber,
		                          string accountNumber,
		                          int customerID,
		                          Nullable<int> salesPersonID,
		                          Nullable<int> territoryID,
		                          int billToAddressID,
		                          int shipToAddressID,
		                          int shipMethodID,
		                          Nullable<int> creditCardID,
		                          string creditCardApprovalCode,
		                          Nullable<int> currencyRateID,
		                          decimal subTotal,
		                          decimal taxAmt,
		                          decimal freight,
		                          decimal totalDue,
		                          string comment,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesOrderHeader ();

			MapPOCOToEF(0, revisionNumber,
			            orderDate,
			            dueDate,
			            shipDate,
			            status,
			            onlineOrderFlag,
			            salesOrderNumber,
			            purchaseOrderNumber,
			            accountNumber,
			            customerID,
			            salesPersonID,
			            territoryID,
			            billToAddressID,
			            shipToAddressID,
			            shipMethodID,
			            creditCardID,
			            creditCardApprovalCode,
			            currencyRateID,
			            subTotal,
			            taxAmt,
			            freight,
			            totalDue,
			            comment,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesOrderHeader>().Add(record);
			this._context.SaveChanges();
			return record.salesOrderID;
		}

		public virtual void Update(int salesOrderID, int revisionNumber,
		                           DateTime orderDate,
		                           DateTime dueDate,
		                           Nullable<DateTime> shipDate,
		                           int status,
		                           bool onlineOrderFlag,
		                           string salesOrderNumber,
		                           string purchaseOrderNumber,
		                           string accountNumber,
		                           int customerID,
		                           Nullable<int> salesPersonID,
		                           Nullable<int> territoryID,
		                           int billToAddressID,
		                           int shipToAddressID,
		                           int shipMethodID,
		                           Nullable<int> creditCardID,
		                           string creditCardApprovalCode,
		                           Nullable<int> currencyRateID,
		                           decimal subTotal,
		                           decimal taxAmt,
		                           decimal freight,
		                           decimal totalDue,
		                           string comment,
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
				MapPOCOToEF(salesOrderID,  revisionNumber,
				            orderDate,
				            dueDate,
				            shipDate,
				            status,
				            onlineOrderFlag,
				            salesOrderNumber,
				            purchaseOrderNumber,
				            accountNumber,
				            customerID,
				            salesPersonID,
				            territoryID,
				            billToAddressID,
				            shipToAddressID,
				            shipMethodID,
				            creditCardID,
				            creditCardApprovalCode,
				            currencyRateID,
				            subTotal,
				            taxAmt,
				            freight,
				            totalDue,
				            comment,
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
				this._context.Set<EFSalesOrderHeader>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int salesOrderID, Response response)
		{
			this.SearchLinqPOCO(x => x.salesOrderID == salesOrderID,response);
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEF(Expression<Func<EFSalesOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderHeader, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int salesOrderID, int revisionNumber,
		                               DateTime orderDate,
		                               DateTime dueDate,
		                               Nullable<DateTime> shipDate,
		                               int status,
		                               bool onlineOrderFlag,
		                               string salesOrderNumber,
		                               string purchaseOrderNumber,
		                               string accountNumber,
		                               int customerID,
		                               Nullable<int> salesPersonID,
		                               Nullable<int> territoryID,
		                               int billToAddressID,
		                               int shipToAddressID,
		                               int shipMethodID,
		                               Nullable<int> creditCardID,
		                               string creditCardApprovalCode,
		                               Nullable<int> currencyRateID,
		                               decimal subTotal,
		                               decimal taxAmt,
		                               decimal freight,
		                               decimal totalDue,
		                               string comment,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesOrderHeader   efSalesOrderHeader)
		{
			efSalesOrderHeader.salesOrderID = salesOrderID;
			efSalesOrderHeader.revisionNumber = revisionNumber;
			efSalesOrderHeader.orderDate = orderDate;
			efSalesOrderHeader.dueDate = dueDate;
			efSalesOrderHeader.shipDate = shipDate;
			efSalesOrderHeader.status = status;
			efSalesOrderHeader.onlineOrderFlag = onlineOrderFlag;
			efSalesOrderHeader.salesOrderNumber = salesOrderNumber;
			efSalesOrderHeader.purchaseOrderNumber = purchaseOrderNumber;
			efSalesOrderHeader.accountNumber = accountNumber;
			efSalesOrderHeader.customerID = customerID;
			efSalesOrderHeader.salesPersonID = salesPersonID;
			efSalesOrderHeader.territoryID = territoryID;
			efSalesOrderHeader.billToAddressID = billToAddressID;
			efSalesOrderHeader.shipToAddressID = shipToAddressID;
			efSalesOrderHeader.shipMethodID = shipMethodID;
			efSalesOrderHeader.creditCardID = creditCardID;
			efSalesOrderHeader.creditCardApprovalCode = creditCardApprovalCode;
			efSalesOrderHeader.currencyRateID = currencyRateID;
			efSalesOrderHeader.subTotal = subTotal;
			efSalesOrderHeader.taxAmt = taxAmt;
			efSalesOrderHeader.freight = freight;
			efSalesOrderHeader.totalDue = totalDue;
			efSalesOrderHeader.comment = comment;
			efSalesOrderHeader.rowguid = rowguid;
			efSalesOrderHeader.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesOrderHeader efSalesOrderHeader,Response response)
		{
			if(efSalesOrderHeader == null)
			{
				return;
			}
			response.AddSalesOrderHeader(new POCOSalesOrderHeader()
			{
				SalesOrderID = efSalesOrderHeader.salesOrderID.ToInt(),
				RevisionNumber = efSalesOrderHeader.revisionNumber,
				OrderDate = efSalesOrderHeader.orderDate.ToDateTime(),
				DueDate = efSalesOrderHeader.dueDate.ToDateTime(),
				ShipDate = efSalesOrderHeader.shipDate.ToNullableDateTime(),
				Status = efSalesOrderHeader.status,
				OnlineOrderFlag = efSalesOrderHeader.onlineOrderFlag,
				SalesOrderNumber = efSalesOrderHeader.salesOrderNumber,
				PurchaseOrderNumber = efSalesOrderHeader.purchaseOrderNumber,
				AccountNumber = efSalesOrderHeader.accountNumber,
				CustomerID = efSalesOrderHeader.customerID.ToInt(),
				SalesPersonID = efSalesOrderHeader.salesPersonID.ToNullableInt(),
				TerritoryID = efSalesOrderHeader.territoryID.ToNullableInt(),
				BillToAddressID = efSalesOrderHeader.billToAddressID.ToInt(),
				ShipToAddressID = efSalesOrderHeader.shipToAddressID.ToInt(),
				ShipMethodID = efSalesOrderHeader.shipMethodID.ToInt(),
				CreditCardID = efSalesOrderHeader.creditCardID.ToNullableInt(),
				CreditCardApprovalCode = efSalesOrderHeader.creditCardApprovalCode,
				CurrencyRateID = efSalesOrderHeader.currencyRateID.ToNullableInt(),
				SubTotal = efSalesOrderHeader.subTotal,
				TaxAmt = efSalesOrderHeader.taxAmt,
				Freight = efSalesOrderHeader.freight,
				TotalDue = efSalesOrderHeader.totalDue,
				Comment = efSalesOrderHeader.comment,
				Rowguid = efSalesOrderHeader.rowguid,
				ModifiedDate = efSalesOrderHeader.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>6941855ce231b6e2420f9fdf40250cc8</Hash>
</Codenesium>*/