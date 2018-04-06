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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID {get; set;}
		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber {get; set;}
		[Column("Status", TypeName="tinyint")]
		public int Status {get; set;}
		[Column("EmployeeID", TypeName="int")]
		public int EmployeeID {get; set;}
		[Column("VendorID", TypeName="int")]
		public int VendorID {get; set;}
		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID {get; set;}
		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate {get; set;}
		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate {get; set;}
		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal {get; set;}
		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt {get; set;}
		[Column("Freight", TypeName="money")]
		public decimal Freight {get; set;}
		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
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
    <Hash>f6d51d5fe0b4549568de28f9a3241920</Hash>
</Codenesium>*/