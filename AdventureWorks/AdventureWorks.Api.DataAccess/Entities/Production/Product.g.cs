using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Product", Schema="Production")]
	public partial class Product : AbstractEntity
	{
		public Product()
		{
		}

		public virtual void SetProperties(
			string @class,
			string color,
			int daysToManufacture,
			DateTime? discontinuedDate,
			bool finishedGoodsFlag,
			decimal listPrice,
			bool makeFlag,
			DateTime modifiedDate,
			string name,
			int productID,
			string productLine,
			int? productModelID,
			string productNumber,
			int? productSubcategoryID,
			short reorderPoint,
			Guid rowguid,
			short safetyStockLevel,
			DateTime? sellEndDate,
			DateTime sellStartDate,
			string size,
			string sizeUnitMeasureCode,
			decimal standardCost,
			string style,
			double? weight,
			string weightUnitMeasureCode)
		{
			this.@Class = @class;
			this.Color = color;
			this.DaysToManufacture = daysToManufacture;
			this.DiscontinuedDate = discontinuedDate;
			this.FinishedGoodsFlag = finishedGoodsFlag;
			this.ListPrice = listPrice;
			this.MakeFlag = makeFlag;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductID = productID;
			this.ProductLine = productLine;
			this.ProductModelID = productModelID;
			this.ProductNumber = productNumber;
			this.ProductSubcategoryID = productSubcategoryID;
			this.ReorderPoint = reorderPoint;
			this.Rowguid = rowguid;
			this.SafetyStockLevel = safetyStockLevel;
			this.SellEndDate = sellEndDate;
			this.SellStartDate = sellStartDate;
			this.Size = size;
			this.SizeUnitMeasureCode = sizeUnitMeasureCode;
			this.StandardCost = standardCost;
			this.Style = style;
			this.Weight = weight;
			this.WeightUnitMeasureCode = weightUnitMeasureCode;
		}

		[Column("Class")]
		public string @Class { get; private set; }

		[Column("Color")]
		public string Color { get; private set; }

		[Column("DaysToManufacture")]
		public int DaysToManufacture { get; private set; }

		[Column("DiscontinuedDate")]
		public DateTime? DiscontinuedDate { get; private set; }

		[Column("FinishedGoodsFlag")]
		public bool FinishedGoodsFlag { get; private set; }

		[Column("ListPrice")]
		public decimal ListPrice { get; private set; }

		[Column("MakeFlag")]
		public bool MakeFlag { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID")]
		public int ProductID { get; private set; }

		[Column("ProductLine")]
		public string ProductLine { get; private set; }

		[Column("ProductModelID")]
		public int? ProductModelID { get; private set; }

		[Column("ProductNumber")]
		public string ProductNumber { get; private set; }

		[Column("ProductSubcategoryID")]
		public int? ProductSubcategoryID { get; private set; }

		[Column("ReorderPoint")]
		public short ReorderPoint { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("SafetyStockLevel")]
		public short SafetyStockLevel { get; private set; }

		[Column("SellEndDate")]
		public DateTime? SellEndDate { get; private set; }

		[Column("SellStartDate")]
		public DateTime SellStartDate { get; private set; }

		[Column("Size")]
		public string Size { get; private set; }

		[Column("SizeUnitMeasureCode")]
		public string SizeUnitMeasureCode { get; private set; }

		[Column("StandardCost")]
		public decimal StandardCost { get; private set; }

		[Column("Style")]
		public string Style { get; private set; }

		[Column("Weight")]
		public double? Weight { get; private set; }

		[Column("WeightUnitMeasureCode")]
		public string WeightUnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d3f7ada44d7770b82a6268a08606c922</Hash>
</Codenesium>*/