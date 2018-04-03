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
		public int productID {get; set;}
		public string name {get; set;}
		public string productNumber {get; set;}
		public bool makeFlag {get; set;}
		public bool finishedGoodsFlag {get; set;}
		public string color {get; set;}
		public short safetyStockLevel {get; set;}
		public short reorderPoint {get; set;}
		public decimal standardCost {get; set;}
		public decimal listPrice {get; set;}
		public string size {get; set;}
		public string sizeUnitMeasureCode {get; set;}
		public string weightUnitMeasureCode {get; set;}
		public Nullable<decimal> weight {get; set;}
		public int daysToManufacture {get; set;}
		public string productLine {get; set;}
		public string @class {get; set;}
		public string style {get; set;}
		public Nullable<int> productSubcategoryID {get; set;}
		public Nullable<int> productModelID {get; set;}
		public DateTime sellStartDate {get; set;}
		public Nullable<DateTime> sellEndDate {get; set;}
		public Nullable<DateTime> discontinuedDate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>fa8f22aa49d16bb27aa27ef83a3068cc</Hash>
</Codenesium>*/