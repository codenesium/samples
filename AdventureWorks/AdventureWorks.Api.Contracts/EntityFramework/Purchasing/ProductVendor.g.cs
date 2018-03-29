using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductVendor", Schema="Purchasing")]
	public partial class EFProductVendor
	{
		public EFProductVendor()
		{}

		[Key]
		public int ProductID {get; set;}
		public int BusinessEntityID {get; set;}
		public int AverageLeadTime {get; set;}
		public decimal StandardPrice {get; set;}
		public Nullable<decimal> LastReceiptCost {get; set;}
		public Nullable<DateTime> LastReceiptDate {get; set;}
		public int MinOrderQty {get; set;}
		public int MaxOrderQty {get; set;}
		public Nullable<int> OnOrderQty {get; set;}
		public string UnitMeasureCode {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("BusinessEntityID")]
		public virtual EFVendor VendorRef { get; set; }
		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasureRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>3d5aa34e9bcd17c3103cb8ccc1b78a75</Hash>
</Codenesium>*/