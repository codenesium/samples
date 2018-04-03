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
		public int salesOrderID {get; set;}
		public int revisionNumber {get; set;}
		public DateTime orderDate {get; set;}
		public DateTime dueDate {get; set;}
		public Nullable<DateTime> shipDate {get; set;}
		public int status {get; set;}
		public bool onlineOrderFlag {get; set;}
		public string salesOrderNumber {get; set;}
		public string purchaseOrderNumber {get; set;}
		public string accountNumber {get; set;}
		public int customerID {get; set;}
		public Nullable<int> salesPersonID {get; set;}
		public Nullable<int> territoryID {get; set;}
		public int billToAddressID {get; set;}
		public int shipToAddressID {get; set;}
		public int shipMethodID {get; set;}
		public Nullable<int> creditCardID {get; set;}
		public string creditCardApprovalCode {get; set;}
		public Nullable<int> currencyRateID {get; set;}
		public decimal subTotal {get; set;}
		public decimal taxAmt {get; set;}
		public decimal freight {get; set;}
		public decimal totalDue {get; set;}
		public string comment {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3f496769af14198b7f2cc4263512c9bc</Hash>
</Codenesium>*/