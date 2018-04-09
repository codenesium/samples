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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesOrderHeaderRepository(ILogger logger,
		                                          ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFSalesOrderHeader>().Add(record);
			this.context.SaveChanges();
			return record.SalesOrderID;
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
			var record =  this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesOrderID}");
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesOrderHeader>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int salesOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID,response);
			return response;
		}

		public virtual POCOSalesOrderHeader GetByIdDirect(int salesOrderID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID,response);
			return response.SalesOrderHeaders.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesOrderHeaders;
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

		protected virtual List<EFSalesOrderHeader> SearchLinqEF(Expression<Func<EFSalesOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efSalesOrderHeader.SetProperties(salesOrderID.ToInt(),revisionNumber,orderDate.ToDateTime(),dueDate.ToDateTime(),shipDate.ToNullableDateTime(),status,onlineOrderFlag,salesOrderNumber,purchaseOrderNumber,accountNumber,customerID.ToInt(),salesPersonID.ToNullableInt(),territoryID.ToNullableInt(),billToAddressID.ToInt(),shipToAddressID.ToInt(),shipMethodID.ToInt(),creditCardID.ToNullableInt(),creditCardApprovalCode,currencyRateID.ToNullableInt(),subTotal,taxAmt,freight,totalDue,comment,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFSalesOrderHeader efSalesOrderHeader,Response response)
		{
			if(efSalesOrderHeader == null)
			{
				return;
			}
			response.AddSalesOrderHeader(new POCOSalesOrderHeader(efSalesOrderHeader.SalesOrderID.ToInt(),efSalesOrderHeader.RevisionNumber,efSalesOrderHeader.OrderDate.ToDateTime(),efSalesOrderHeader.DueDate.ToDateTime(),efSalesOrderHeader.ShipDate.ToNullableDateTime(),efSalesOrderHeader.Status,efSalesOrderHeader.OnlineOrderFlag,efSalesOrderHeader.SalesOrderNumber,efSalesOrderHeader.PurchaseOrderNumber,efSalesOrderHeader.AccountNumber,efSalesOrderHeader.CustomerID.ToInt(),efSalesOrderHeader.SalesPersonID.ToNullableInt(),efSalesOrderHeader.TerritoryID.ToNullableInt(),efSalesOrderHeader.BillToAddressID.ToInt(),efSalesOrderHeader.ShipToAddressID.ToInt(),efSalesOrderHeader.ShipMethodID.ToInt(),efSalesOrderHeader.CreditCardID.ToNullableInt(),efSalesOrderHeader.CreditCardApprovalCode,efSalesOrderHeader.CurrencyRateID.ToNullableInt(),efSalesOrderHeader.SubTotal,efSalesOrderHeader.TaxAmt,efSalesOrderHeader.Freight,efSalesOrderHeader.TotalDue,efSalesOrderHeader.Comment,efSalesOrderHeader.Rowguid,efSalesOrderHeader.ModifiedDate.ToDateTime()));

			CustomerRepository.MapEFToPOCO(efSalesOrderHeader.Customer, response);

			SalesPersonRepository.MapEFToPOCO(efSalesOrderHeader.SalesPerson, response);

			SalesTerritoryRepository.MapEFToPOCO(efSalesOrderHeader.SalesTerritory, response);

			AddressRepository.MapEFToPOCO(efSalesOrderHeader.Address, response);

			AddressRepository.MapEFToPOCO(efSalesOrderHeader.Address1, response);

			ShipMethodRepository.MapEFToPOCO(efSalesOrderHeader.ShipMethod, response);

			CreditCardRepository.MapEFToPOCO(efSalesOrderHeader.CreditCard, response);

			CurrencyRateRepository.MapEFToPOCO(efSalesOrderHeader.CurrencyRate, response);
		}
	}
}

/*<Codenesium>
    <Hash>24d214a1abafbd0e23037e3d81823741</Hash>
</Codenesium>*/