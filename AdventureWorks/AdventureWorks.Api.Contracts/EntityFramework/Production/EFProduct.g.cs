using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
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
			this.Name = name;
			this.ProductNumber = productNumber;
			this.MakeFlag = makeFlag;
			this.FinishedGoodsFlag = finishedGoodsFlag;
			this.Color = color;
			this.SafetyStockLevel = safetyStockLevel;
			this.ReorderPoint = reorderPoint;
			this.StandardCost = standardCost;
			this.ListPrice = listPrice;
			this.Size = size;
			this.SizeUnitMeasureCode = sizeUnitMeasureCode;
			this.WeightUnitMeasureCode = weightUnitMeasureCode;
			this.Weight = weight.ToNullableDecimal();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.ProductLine = productLine;
			this.@Class = @class;
			this.Style = style;
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ProductModelID = productModelID.ToNullableInt();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.Rowguid = rowguid;
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
    <Hash>f193724845f6bd1fe0bbe1f3e0c80f1e</Hash>
</Codenesium>*/