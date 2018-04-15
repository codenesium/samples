using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Product", Schema="Production")]
	public partial class EFProduct
	{
		public EFProduct()
		{}

		public void SetProperties(
			int productID,
			string name,
			string productNumber,
			bool makeFlag,
			bool finishedGoodsFlag,
			string color,
			short safetyStockLevel,
			short reorderPoint,
			decimal standardCost,
			decimal listPrice,
			string size,
			string sizeUnitMeasureCode,
			string weightUnitMeasureCode,
			Nullable<decimal> weight,
			int daysToManufacture,
			string productLine,
			string @class,
			string style,
			Nullable<int> productSubcategoryID,
			Nullable<int> productModelID,
			DateTime sellStartDate,
			Nullable<DateTime> sellEndDate,
			Nullable<DateTime> discontinuedDate,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.Name = name.ToString();
			this.ProductNumber = productNumber.ToString();
			this.MakeFlag = makeFlag.ToBoolean();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.Color = color.ToString();
			this.SafetyStockLevel = safetyStockLevel;
			this.ReorderPoint = reorderPoint;
			this.StandardCost = standardCost.ToDecimal();
			this.ListPrice = listPrice.ToDecimal();
			this.Size = size.ToString();
			this.SizeUnitMeasureCode = sizeUnitMeasureCode.ToString();
			this.WeightUnitMeasureCode = weightUnitMeasureCode.ToString();
			this.Weight = weight.ToNullableDecimal();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.ProductLine = productLine.ToString();
			this.@Class = @class.ToString();
			this.Style = style.ToString();
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ProductModelID = productModelID.ToNullableInt();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ProductNumber", TypeName="nvarchar(25)")]
		public string ProductNumber { get; set; }

		[Column("MakeFlag", TypeName="bit")]
		public bool MakeFlag { get; set; }

		[Column("FinishedGoodsFlag", TypeName="bit")]
		public bool FinishedGoodsFlag { get; set; }

		[Column("Color", TypeName="nvarchar(15)")]
		public string Color { get; set; }

		[Column("SafetyStockLevel", TypeName="smallint")]
		public short SafetyStockLevel { get; set; }

		[Column("ReorderPoint", TypeName="smallint")]
		public short ReorderPoint { get; set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; set; }

		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice { get; set; }

		[Column("Size", TypeName="nvarchar(5)")]
		public string Size { get; set; }

		[Column("SizeUnitMeasureCode", TypeName="nchar(3)")]
		public string SizeUnitMeasureCode { get; set; }

		[Column("WeightUnitMeasureCode", TypeName="nchar(3)")]
		public string WeightUnitMeasureCode { get; set; }

		[Column("Weight", TypeName="decimal")]
		public Nullable<decimal> Weight { get; set; }

		[Column("DaysToManufacture", TypeName="int")]
		public int DaysToManufacture { get; set; }

		[Column("ProductLine", TypeName="nchar(2)")]
		public string ProductLine { get; set; }

		[Column("Class", TypeName="nchar(2)")]
		public string @Class { get; set; }

		[Column("Style", TypeName="nchar(2)")]
		public string Style { get; set; }

		[Column("ProductSubcategoryID", TypeName="int")]
		public Nullable<int> ProductSubcategoryID { get; set; }

		[Column("ProductModelID", TypeName="int")]
		public Nullable<int> ProductModelID { get; set; }

		[Column("SellStartDate", TypeName="datetime")]
		public DateTime SellStartDate { get; set; }

		[Column("SellEndDate", TypeName="datetime")]
		public Nullable<DateTime> SellEndDate { get; set; }

		[Column("DiscontinuedDate", TypeName="datetime")]
		public Nullable<DateTime> DiscontinuedDate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("SizeUnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure { get; set; }

		[ForeignKey("WeightUnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure1 { get; set; }

		[ForeignKey("ProductSubcategoryID")]
		public virtual EFProductSubcategory ProductSubcategory { get; set; }

		[ForeignKey("ProductModelID")]
		public virtual EFProductModel ProductModel { get; set; }
	}
}

/*<Codenesium>
    <Hash>36e2522928b9d9492fa2617514ec917a</Hash>
</Codenesium>*/