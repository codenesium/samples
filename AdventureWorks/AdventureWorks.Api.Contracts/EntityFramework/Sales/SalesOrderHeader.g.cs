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
		public int SalesOrderID {get; set;}
		public int RevisionNumber {get; set;}
		public DateTime OrderDate {get; set;}
		public DateTime DueDate {get; set;}
		public Nullable<DateTime> ShipDate {get; set;}
		public int Status {get; set;}
		public bool OnlineOrderFlag {get; set;}
		public string SalesOrderNumber {get; set;}
		public string PurchaseOrderNumber {get; set;}
		public string AccountNumber {get; set;}
		public int CustomerID {get; set;}
		public Nullable<int> SalesPersonID {get; set;}
		public Nullable<int> TerritoryID {get; set;}
		public int BillToAddressID {get; set;}
		public int ShipToAddressID {get; set;}
		public int ShipMethodID {get; set;}
		public Nullable<int> CreditCardID {get; set;}
		public string CreditCardApprovalCode {get; set;}
		public Nullable<int> CurrencyRateID {get; set;}
		public decimal SubTotal {get; set;}
		public decimal TaxAmt {get; set;}
		public decimal Freight {get; set;}
		public decimal TotalDue {get; set;}
		public string Comment {get; set;}
		public Guid rowguid {get; set;}
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
    <Hash>1d177dcdb7772b50898337fc68b8597c</Hash>
</Codenesium>*/