using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSalesOrderHeader: AbstractBusinessObject
	{
		public BOSalesOrderHeader() : base()
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

		public string AccountNumber { get; private set; }
		public int BillToAddressID { get; private set; }
		public string Comment { get; private set; }
		public string CreditCardApprovalCode { get; private set; }
		public Nullable<int> CreditCardID { get; private set; }
		public Nullable<int> CurrencyRateID { get; private set; }
		public int CustomerID { get; private set; }
		public DateTime DueDate { get; private set; }
		public decimal Freight { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public bool OnlineOrderFlag { get; private set; }
		public DateTime OrderDate { get; private set; }
		public string PurchaseOrderNumber { get; private set; }
		public int RevisionNumber { get; private set; }
		public Guid Rowguid { get; private set; }
		public int SalesOrderID { get; private set; }
		public string SalesOrderNumber { get; private set; }
		public Nullable<int> SalesPersonID { get; private set; }
		public Nullable<DateTime> ShipDate { get; private set; }
		public int ShipMethodID { get; private set; }
		public int ShipToAddressID { get; private set; }
		public int Status { get; private set; }
		public decimal SubTotal { get; private set; }
		public decimal TaxAmt { get; private set; }
		public Nullable<int> TerritoryID { get; private set; }
		public decimal TotalDue { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7c3f08dd27740a4b2c25379885fe91a8</Hash>
</Codenesium>*/