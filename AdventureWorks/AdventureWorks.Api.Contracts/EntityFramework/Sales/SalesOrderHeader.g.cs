using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderHeader", Schema="Sales")]
	public partial class EFSalesOrderHeader
	{
		public EFSalesOrderHeader()
		{}

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

		[ForeignKey("CustomerID")]
		public virtual EFCustomer CustomerRef { get; set; }
		[ForeignKey("SalesPersonID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
		[ForeignKey("BillToAddressID")]
		public virtual EFAddress AddressRef { get; set; }
		[ForeignKey("ShipToAddressID")]
		public virtual EFAddress AddressRef1 { get; set; }
		[ForeignKey("ShipMethodID")]
		public virtual EFShipMethod ShipMethodRef { get; set; }
		[ForeignKey("CreditCardID")]
		public virtual EFCreditCard CreditCardRef { get; set; }
		[ForeignKey("CurrencyRateID")]
		public virtual EFCurrencyRate CurrencyRateRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>790a65bb6507c474f0e5001456926526</Hash>
</Codenesium>*/