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
			int productID,
			string color,
			int daysToManufacture,
			DateTime? discontinuedDate,
			bool finishedGoodsFlag,
			decimal listPrice,
			bool makeFlag,
			DateTime modifiedDate,
			string name,
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
			this.ProductID = productID;
			this.Color = color;
			this.DaysToManufacture = daysToManufacture;
			this.DiscontinuedDate = discontinuedDate;
			this.FinishedGoodsFlag = finishedGoodsFlag;
			this.ListPrice = listPrice;
			this.MakeFlag = makeFlag;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
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

		[MaxLength(15)]
		[Column("Color")]
		public virtual string Color { get; private set; }

		[Column("DaysToManufacture")]
		public virtual int DaysToManufacture { get; private set; }

		[Column("DiscontinuedDate")]
		public virtual DateTime? DiscontinuedDate { get; private set; }

		[Column("FinishedGoodsFlag")]
		public virtual bool FinishedGoodsFlag { get; private set; }

		[Column("ListPrice")]
		public virtual decimal ListPrice { get; private set; }

		[Column("MakeFlag")]
		public virtual bool MakeFlag { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[MaxLength(2)]
		[Column("ProductLine")]
		public virtual string ProductLine { get; private set; }

		[Column("ProductModelID")]
		public virtual int? ProductModelID { get; private set; }

		[MaxLength(25)]
		[Column("ProductNumber")]
		public virtual string ProductNumber { get; private set; }

		[Column("ProductSubcategoryID")]
		public virtual int? ProductSubcategoryID { get; private set; }

		[Column("ReorderPoint")]
		public virtual short ReorderPoint { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SafetyStockLevel")]
		public virtual short SafetyStockLevel { get; private set; }

		[Column("SellEndDate")]
		public virtual DateTime? SellEndDate { get; private set; }

		[Column("SellStartDate")]
		public virtual DateTime SellStartDate { get; private set; }

		[MaxLength(5)]
		[Column("Size")]
		public virtual string Size { get; private set; }

		[MaxLength(3)]
		[Column("SizeUnitMeasureCode")]
		public virtual string SizeUnitMeasureCode { get; private set; }

		[Column("StandardCost")]
		public virtual decimal StandardCost { get; private set; }

		[MaxLength(2)]
		[Column("Style")]
		public virtual string Style { get; private set; }

		[Column("Weight")]
		public virtual double? Weight { get; private set; }

		[MaxLength(3)]
		[Column("WeightUnitMeasureCode")]
		public virtual string WeightUnitMeasureCode { get; private set; }

		[ForeignKey("ProductModelID")]
		public virtual ProductModel ProductModelIDNavigation { get; private set; }

		public void SetProductModelIDNavigation(ProductModel item)
		{
			this.ProductModelIDNavigation = item;
		}

		[ForeignKey("ProductSubcategoryID")]
		public virtual ProductSubcategory ProductSubcategoryIDNavigation { get; private set; }

		public void SetProductSubcategoryIDNavigation(ProductSubcategory item)
		{
			this.ProductSubcategoryIDNavigation = item;
		}

		[ForeignKey("SizeUnitMeasureCode")]
		public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; private set; }

		public void SetSizeUnitMeasureCodeNavigation(UnitMeasure item)
		{
			this.SizeUnitMeasureCodeNavigation = item;
		}

		[ForeignKey("WeightUnitMeasureCode")]
		public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; private set; }

		public void SetWeightUnitMeasureCodeNavigation(UnitMeasure item)
		{
			this.WeightUnitMeasureCodeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e0748913bc729913815a0f38f5cd1263</Hash>
</Codenesium>*/