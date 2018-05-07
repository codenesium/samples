using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Product", Schema="Production")]
	public partial class EFProduct: AbstractEntityFrameworkPOCO
	{
		public EFProduct()
		{}

		public void SetProperties(
			int productID,
			string @class,
			string color,
			int daysToManufacture,
			Nullable<DateTime> discontinuedDate,
			bool finishedGoodsFlag,
			decimal listPrice,
			bool makeFlag,
			DateTime modifiedDate,
			string name,
			string productLine,
			Nullable<int> productModelID,
			string productNumber,
			Nullable<int> productSubcategoryID,
			short reorderPoint,
			Guid rowguid,
			short safetyStockLevel,
			Nullable<DateTime> sellEndDate,
			DateTime sellStartDate,
			string size,
			string sizeUnitMeasureCode,
			decimal standardCost,
			string style,
			Nullable<decimal> weight,
			string weightUnitMeasureCode)
		{
			this.@Class = @class.ToString();
			this.Color = color.ToString();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.ListPrice = listPrice.ToDecimal();
			this.MakeFlag = makeFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductID = productID.ToInt();
			this.ProductLine = productLine.ToString();
			this.ProductModelID = productModelID.ToNullableInt();
			this.ProductNumber = productNumber.ToString();
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ReorderPoint = reorderPoint;
			this.Rowguid = rowguid.ToGuid();
			this.SafetyStockLevel = safetyStockLevel;
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.Size = size.ToString();
			this.SizeUnitMeasureCode = sizeUnitMeasureCode.ToString();
			this.StandardCost = standardCost.ToDecimal();
			this.Style = style.ToString();
			this.Weight = weight.ToNullableDecimal();
			this.WeightUnitMeasureCode = weightUnitMeasureCode.ToString();
		}

		[Column("Class", TypeName="nchar(2)")]
		public string @Class { get; set; }

		[Column("Color", TypeName="nvarchar(15)")]
		public string Color { get; set; }

		[Column("DaysToManufacture", TypeName="int")]
		public int DaysToManufacture { get; set; }

		[Column("DiscontinuedDate", TypeName="datetime")]
		public Nullable<DateTime> DiscontinuedDate { get; set; }

		[Column("FinishedGoodsFlag", TypeName="bit")]
		public bool FinishedGoodsFlag { get; set; }

		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice { get; set; }

		[Column("MakeFlag", TypeName="bit")]
		public bool MakeFlag { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ProductLine", TypeName="nchar(2)")]
		public string ProductLine { get; set; }

		[Column("ProductModelID", TypeName="int")]
		public Nullable<int> ProductModelID { get; set; }

		[Column("ProductNumber", TypeName="nvarchar(25)")]
		public string ProductNumber { get; set; }

		[Column("ProductSubcategoryID", TypeName="int")]
		public Nullable<int> ProductSubcategoryID { get; set; }

		[Column("ReorderPoint", TypeName="smallint")]
		public short ReorderPoint { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SafetyStockLevel", TypeName="smallint")]
		public short SafetyStockLevel { get; set; }

		[Column("SellEndDate", TypeName="datetime")]
		public Nullable<DateTime> SellEndDate { get; set; }

		[Column("SellStartDate", TypeName="datetime")]
		public DateTime SellStartDate { get; set; }

		[Column("Size", TypeName="nvarchar(5)")]
		public string Size { get; set; }

		[Column("SizeUnitMeasureCode", TypeName="nchar(3)")]
		public string SizeUnitMeasureCode { get; set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; set; }

		[Column("Style", TypeName="nchar(2)")]
		public string Style { get; set; }

		[Column("Weight", TypeName="decimal")]
		public Nullable<decimal> Weight { get; set; }

		[Column("WeightUnitMeasureCode", TypeName="nchar(3)")]
		public string WeightUnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>2491364d1d7dbc0298e58459aac50485</Hash>
</Codenesium>*/