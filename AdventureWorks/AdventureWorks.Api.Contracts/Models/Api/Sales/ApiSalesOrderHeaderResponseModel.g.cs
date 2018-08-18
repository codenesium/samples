using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int salesOrderID,
			string accountNumber,
			int billToAddressID,
			string comment,
			string creditCardApprovalCode,
			int? creditCardID,
			int? currencyRateID,
			int customerID,
			DateTime dueDate,
			decimal freight,
			DateTime modifiedDate,
			bool onlineOrderFlag,
			DateTime orderDate,
			string purchaseOrderNumber,
			int revisionNumber,
			Guid rowguid,
			string salesOrderNumber,
			int? salesPersonID,
			DateTime? shipDate,
			int shipMethodID,
			int shipToAddressID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			int? territoryID,
			decimal totalDue)
		{
			this.SalesOrderID = salesOrderID;
			this.AccountNumber = accountNumber;
			this.BillToAddressID = billToAddressID;
			this.Comment = comment;
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.CreditCardID = creditCardID;
			this.CurrencyRateID = currencyRateID;
			this.CustomerID = customerID;
			this.DueDate = dueDate;
			this.Freight = freight;
			this.ModifiedDate = modifiedDate;
			this.OnlineOrderFlag = onlineOrderFlag;
			this.OrderDate = orderDate;
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.RevisionNumber = revisionNumber;
			this.Rowguid = rowguid;
			this.SalesOrderNumber = salesOrderNumber;
			this.SalesPersonID = salesPersonID;
			this.ShipDate = shipDate;
			this.ShipMethodID = shipMethodID;
			this.ShipToAddressID = shipToAddressID;
			this.Status = status;
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.TerritoryID = territoryID;
			this.TotalDue = totalDue;

			this.CreditCardIDEntity = nameof(ApiResponse.CreditCards);
			this.CurrencyRateIDEntity = nameof(ApiResponse.CurrencyRates);
			this.CustomerIDEntity = nameof(ApiResponse.Customers);
			this.SalesPersonIDEntity = nameof(ApiResponse.SalesPersons);
			this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
		}

		[Required]
		[JsonProperty]
		public string AccountNumber { get; private set; }

		[JsonProperty]
		public int BillToAddressID { get; private set; }

		[Required]
		[JsonProperty]
		public string Comment { get; private set; }

		[Required]
		[JsonProperty]
		public string CreditCardApprovalCode { get; private set; }

		[Required]
		[JsonProperty]
		public int? CreditCardID { get; private set; }

		[JsonProperty]
		public string CreditCardIDEntity { get; set; }

		[Required]
		[JsonProperty]
		public int? CurrencyRateID { get; private set; }

		[JsonProperty]
		public string CurrencyRateIDEntity { get; set; }

		[JsonProperty]
		public int CustomerID { get; private set; }

		[JsonProperty]
		public string CustomerIDEntity { get; set; }

		[JsonProperty]
		public DateTime DueDate { get; private set; }

		[JsonProperty]
		public decimal Freight { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public bool OnlineOrderFlag { get; private set; }

		[JsonProperty]
		public DateTime OrderDate { get; private set; }

		[Required]
		[JsonProperty]
		public string PurchaseOrderNumber { get; private set; }

		[JsonProperty]
		public int RevisionNumber { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SalesOrderID { get; private set; }

		[JsonProperty]
		public string SalesOrderNumber { get; private set; }

		[Required]
		[JsonProperty]
		public int? SalesPersonID { get; private set; }

		[JsonProperty]
		public string SalesPersonIDEntity { get; set; }

		[Required]
		[JsonProperty]
		public DateTime? ShipDate { get; private set; }

		[JsonProperty]
		public int ShipMethodID { get; private set; }

		[JsonProperty]
		public int ShipToAddressID { get; private set; }

		[JsonProperty]
		public int Status { get; private set; }

		[JsonProperty]
		public decimal SubTotal { get; private set; }

		[JsonProperty]
		public decimal TaxAmt { get; private set; }

		[Required]
		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; set; }

		[JsonProperty]
		public decimal TotalDue { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fde0b8116caf10a587fafa2f0a331ed1</Hash>
</Codenesium>*/