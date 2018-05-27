using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesOrderHeader: AbstractDTO
	{
		public DTOSalesOrderHeader() : base()
		{}

		public void SetProperties(int salesOrderID,
		                          string accountNumber,
		                          int billToAddressID,
		                          string comment,
		                          string creditCardApprovalCode,
		                          Nullable<int> creditCardID,
		                          Nullable<int> currencyRateID,
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
		                          Nullable<int> salesPersonID,
		                          Nullable<DateTime> shipDate,
		                          int shipMethodID,
		                          int shipToAddressID,
		                          int status,
		                          decimal subTotal,
		                          decimal taxAmt,
		                          Nullable<int> territoryID,
		                          decimal totalDue)
		{
			this.AccountNumber = accountNumber;
			this.BillToAddressID = billToAddressID.ToInt();
			this.Comment = comment;
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.CreditCardID = creditCardID.ToNullableInt();
			this.CurrencyRateID = currencyRateID.ToNullableInt();
			this.CustomerID = customerID.ToInt();
			this.DueDate = dueDate.ToDateTime();
			this.Freight = freight.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OnlineOrderFlag = onlineOrderFlag.ToBoolean();
			this.OrderDate = orderDate.ToDateTime();
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.RevisionNumber = revisionNumber.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesOrderNumber = salesOrderNumber;
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.Status = status.ToInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.TerritoryID = territoryID.ToNullableInt();
			this.TotalDue = totalDue.ToDecimal();
		}

		public string AccountNumber { get; set; }
		public int BillToAddressID { get; set; }
		public string Comment { get; set; }
		public string CreditCardApprovalCode { get; set; }
		public Nullable<int> CreditCardID { get; set; }
		public Nullable<int> CurrencyRateID { get; set; }
		public int CustomerID { get; set; }
		public DateTime DueDate { get; set; }
		public decimal Freight { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool OnlineOrderFlag { get; set; }
		public DateTime OrderDate { get; set; }
		public string PurchaseOrderNumber { get; set; }
		public int RevisionNumber { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesOrderID { get; set; }
		public string SalesOrderNumber { get; set; }
		public Nullable<int> SalesPersonID { get; set; }
		public Nullable<DateTime> ShipDate { get; set; }
		public int ShipMethodID { get; set; }
		public int ShipToAddressID { get; set; }
		public int Status { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmt { get; set; }
		public Nullable<int> TerritoryID { get; set; }
		public decimal TotalDue { get; set; }
	}
}

/*<Codenesium>
    <Hash>78be5860b7711cc8a863e4ef5a2e3232</Hash>
</Codenesium>*/