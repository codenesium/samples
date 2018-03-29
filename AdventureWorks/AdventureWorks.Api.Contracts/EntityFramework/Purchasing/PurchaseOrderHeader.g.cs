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
		public int PurchaseOrderID {get; set;}
		public int RevisionNumber {get; set;}
		public int Status {get; set;}
		public int EmployeeID {get; set;}
		public int VendorID {get; set;}
		public int ShipMethodID {get; set;}
		public DateTime OrderDate {get; set;}
		public Nullable<DateTime> ShipDate {get; set;}
		public decimal SubTotal {get; set;}
		public decimal TaxAmt {get; set;}
		public decimal Freight {get; set;}
		public decimal TotalDue {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("EmployeeID")]
		public virtual EFEmployee EmployeeRef { get; set; }
		[ForeignKey("VendorID")]
		public virtual EFVendor VendorRef { get; set; }
		[ForeignKey("ShipMethodID")]
		public virtual EFShipMethod ShipMethodRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>7af1b8de9644b964c96a5c01b708e0f3</Hash>
</Codenesium>*/