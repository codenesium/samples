using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PurchaseOrderHeader", Schema="Purchasing")]
	public partial class EFPurchaseOrderHeader
	{
		public EFPurchaseOrderHeader()
		{}

		[Key]
		public int purchaseOrderID {get; set;}
		public int revisionNumber {get; set;}
		public int status {get; set;}
		public int employeeID {get; set;}
		public int vendorID {get; set;}
		public int shipMethodID {get; set;}
		public DateTime orderDate {get; set;}
		public Nullable<DateTime> shipDate {get; set;}
		public decimal subTotal {get; set;}
		public decimal taxAmt {get; set;}
		public decimal freight {get; set;}
		public decimal totalDue {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>338b1dfc3de2c0b082cf589fd79138c6</Hash>
</Codenesium>*/