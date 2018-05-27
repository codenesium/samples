using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProduct: AbstractDTO
	{
		public DTOProduct() : base()
		{}

		public void SetProperties(int productID,
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

		public string @Class { get; set; }
		public string Color { get; set; }
		public int DaysToManufacture { get; set; }
		public Nullable<DateTime> DiscontinuedDate { get; set; }
		public bool FinishedGoodsFlag { get; set; }
		public decimal ListPrice { get; set; }
		public bool MakeFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductID { get; set; }
		public string ProductLine { get; set; }
		public Nullable<int> ProductModelID { get; set; }
		public string ProductNumber { get; set; }
		public Nullable<int> ProductSubcategoryID { get; set; }
		public short ReorderPoint { get; set; }
		public Guid Rowguid { get; set; }
		public short SafetyStockLevel { get; set; }
		public Nullable<DateTime> SellEndDate { get; set; }
		public DateTime SellStartDate { get; set; }
		public string Size { get; set; }
		public string SizeUnitMeasureCode { get; set; }
		public decimal StandardCost { get; set; }
		public string Style { get; set; }
		public Nullable<decimal> Weight { get; set; }
		public string WeightUnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>236a35a117f7ac68328b8dfb94ad4630</Hash>
</Codenesium>*/