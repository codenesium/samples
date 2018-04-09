using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderHeader", Schema="Sales")]
	public partial class EFSalesOrderHeader
	{
		public EFSalesOrderHeader()
		{}

		public void SetProperties(int salesOrderID,
		                          int revisionNumber,
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
			this.SalesOrderID = salesOrderID.ToInt();
			this.RevisionNumber = revisionNumber;
			this.OrderDate = orderDate.ToDateTime();
			this.DueDate = dueDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.Status = status;
			this.OnlineOrderFlag = onlineOrderFlag;
			this.SalesOrderNumber = salesOrderNumber;
			this.PurchaseOrderNumber = purchaseOrderNumber;
			this.AccountNumber = accountNumber;
			this.CustomerID = customerID.ToInt();
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.BillToAddressID = billToAddressID.ToInt();
			this.ShipToAddressID = shipToAddressID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.CreditCardID = creditCardID.ToNullableInt();
			this.CreditCardApprovalCode = creditCardApprovalCode;
			this.CurrencyRateID = currencyRateID.ToNullableInt();
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.Freight = freight;
			this.TotalDue = totalDue;
			this.Comment = comment;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID {get; set;}

		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber {get; set;}

		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate {get; set;}

		[Column("DueDate", TypeName="datetime")]
		public DateTime DueDate {get; set;}

		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate {get; set;}

		[Column("Status", TypeName="tinyint")]
		public int Status {get; set;}

		[Column("OnlineOrderFlag", TypeName="bit")]
		public bool OnlineOrderFlag {get; set;}

		[Column("SalesOrderNumber", TypeName="nvarchar(25)")]
		public string SalesOrderNumber {get; set;}

		[Column("PurchaseOrderNumber", TypeName="nvarchar(25)")]
		public string PurchaseOrderNumber {get; set;}

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber {get; set;}

		[Column("CustomerID", TypeName="int")]
		public int CustomerID {get; set;}

		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID {get; set;}

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID {get; set;}

		[Column("BillToAddressID", TypeName="int")]
		public int BillToAddressID {get; set;}

		[Column("ShipToAddressID", TypeName="int")]
		public int ShipToAddressID {get; set;}

		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID {get; set;}

		[Column("CreditCardID", TypeName="int")]
		public Nullable<int> CreditCardID {get; set;}

		[Column("CreditCardApprovalCode", TypeName="varchar(15)")]
		public string CreditCardApprovalCode {get; set;}

		[Column("CurrencyRateID", TypeName="int")]
		public Nullable<int> CurrencyRateID {get; set;}

		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal {get; set;}

		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt {get; set;}

		[Column("Freight", TypeName="money")]
		public decimal Freight {get; set;}

		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue {get; set;}

		[Column("Comment", TypeName="nvarchar(128)")]
		public string Comment {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFCustomer Customer { get; set; }

		public virtual EFSalesPerson SalesPerson { get; set; }

		public virtual EFSalesTerritory SalesTerritory { get; set; }

		public virtual EFAddress Address { get; set; }

		public virtual EFAddress Address1 { get; set; }

		public virtual EFShipMethod ShipMethod { get; set; }

		public virtual EFCreditCard CreditCard { get; set; }

		public virtual EFCurrencyRate CurrencyRate { get; set; }
	}
}

/*<Codenesium>
    <Hash>81a81dbd99f16dc8e1bdfdaf34e61bad</Hash>
</Codenesium>*/