using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Product", Schema="Production")]
	public partial class EFProduct
	{
		public EFProduct()
		{}

		[Key]
		public int ProductID {get; set;}
		public string Name {get; set;}
		public string ProductNumber {get; set;}
		public bool MakeFlag {get; set;}
		public bool FinishedGoodsFlag {get; set;}
		public string Color {get; set;}
		public short SafetyStockLevel {get; set;}
		public short ReorderPoint {get; set;}
		public decimal StandardCost {get; set;}
		public decimal ListPrice {get; set;}
		public string Size {get; set;}
		public string SizeUnitMeasureCode {get; set;}
		public string WeightUnitMeasureCode {get; set;}
		public Nullable<decimal> Weight {get; set;}
		public int DaysToManufacture {get; set;}
		public string ProductLine {get; set;}
		public string @Class {get; set;}
		public string Style {get; set;}
		public Nullable<int> ProductSubcategoryID {get; set;}
		public Nullable<int> ProductModelID {get; set;}
		public DateTime SellStartDate {get; set;}
		public Nullable<DateTime> SellEndDate {get; set;}
		public Nullable<DateTime> DiscontinuedDate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("SizeUnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasureRef { get; set; }
		[ForeignKey("WeightUnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasureRef1 { get; set; }
		[ForeignKey("ProductSubcategoryID")]
		public virtual EFProductSubcategory ProductSubcategoryRef { get; set; }
		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModelRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>f50a55a5c9ea363647052c6a66d16f9c</Hash>
</Codenesium>*/