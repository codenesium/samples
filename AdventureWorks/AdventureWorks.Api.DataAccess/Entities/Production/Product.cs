using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Product", Schema="Production")]
	public partial class Product: AbstractEntity
	{
		public Product()
		{}

		public void SetProperties(
			string @class,
			string color,
			int daysToManufacture,
			Nullable<DateTime> discontinuedDate,
			bool finishedGoodsFlag,
			decimal listPrice,
			bool makeFlag,
			DateTime modifiedDate,
			string name,
			int productID,
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
			this.@Class = @class;
			this.Color = color;
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.ListPrice = listPrice.ToDecimal();
			this.MakeFlag = makeFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductID = productID.ToInt();
			this.ProductLine = productLine;
			this.ProductModelID = productModelID.ToNullableInt();
			this.ProductNumber = productNumber;
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ReorderPoint = reorderPoint;
			this.Rowguid = rowguid.ToGuid();
			this.SafetyStockLevel = safetyStockLevel;
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.Size = size;
			this.SizeUnitMeasureCode = sizeUnitMeasureCode;
			this.StandardCost = standardCost.ToDecimal();
			this.Style = style;
			this.Weight = weight.ToNullableDecimal();
			this.WeightUnitMeasureCode = weightUnitMeasureCode;
		}

		[Column("Class", TypeName="nchar(2)")]
		public string @Class { get; private set; }

		[Column("Color", TypeName="nvarchar(15)")]
		public string Color { get; private set; }

		[Column("DaysToManufacture", TypeName="int")]
		public int DaysToManufacture { get; private set; }

		[Column("DiscontinuedDate", TypeName="datetime")]
		public Nullable<DateTime> DiscontinuedDate { get; private set; }

		[Column("FinishedGoodsFlag", TypeName="bit")]
		public bool FinishedGoodsFlag { get; private set; }

		[Column("ListPrice", TypeName="money")]
		public decimal ListPrice { get; private set; }

		[Column("MakeFlag", TypeName="bit")]
		public bool MakeFlag { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Key]
		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("ProductLine", TypeName="nchar(2)")]
		public string ProductLine { get; private set; }

		[Column("ProductModelID", TypeName="int")]
		public Nullable<int> ProductModelID { get; private set; }

		[Column("ProductNumber", TypeName="nvarchar(25)")]
		public string ProductNumber { get; private set; }

		[Column("ProductSubcategoryID", TypeName="int")]
		public Nullable<int> ProductSubcategoryID { get; private set; }

		[Column("ReorderPoint", TypeName="smallint")]
		public short ReorderPoint { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("SafetyStockLevel", TypeName="smallint")]
		public short SafetyStockLevel { get; private set; }

		[Column("SellEndDate", TypeName="datetime")]
		public Nullable<DateTime> SellEndDate { get; private set; }

		[Column("SellStartDate", TypeName="datetime")]
		public DateTime SellStartDate { get; private set; }

		[Column("Size", TypeName="nvarchar(5)")]
		public string Size { get; private set; }

		[Column("SizeUnitMeasureCode", TypeName="nchar(3)")]
		public string SizeUnitMeasureCode { get; private set; }

		[Column("StandardCost", TypeName="money")]
		public decimal StandardCost { get; private set; }

		[Column("Style", TypeName="nchar(2)")]
		public string Style { get; private set; }

		[Column("Weight", TypeName="decimal")]
		public Nullable<decimal> Weight { get; private set; }

		[Column("WeightUnitMeasureCode", TypeName="nchar(3)")]
		public string WeightUnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>da1105d9ead91c4156f80194b7d0139d</Hash>
</Codenesium>*/