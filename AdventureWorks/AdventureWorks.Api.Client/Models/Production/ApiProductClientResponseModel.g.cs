using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductClientResponseModel : AbstractApiClientResponseModel
	{
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
			string reservedClass,
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
			this.ReservedClass = reservedClass;
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

			this.ProductModelIDEntity = nameof(ApiResponse.ProductModels);

			this.ProductSubcategoryIDEntity = nameof(ApiResponse.ProductSubcategories);

			this.SizeUnitMeasureCodeEntity = nameof(ApiResponse.UnitMeasures);

			this.WeightUnitMeasureCodeEntity = nameof(ApiResponse.UnitMeasures);
		}

		[JsonProperty]
		public ApiProductModelClientResponseModel ProductModelIDNavigation { get; private set; }

		public void SetProductModelIDNavigation(ApiProductModelClientResponseModel value)
		{
			this.ProductModelIDNavigation = value;
		}

		[JsonProperty]
		public ApiProductSubcategoryClientResponseModel ProductSubcategoryIDNavigation { get; private set; }

		public void SetProductSubcategoryIDNavigation(ApiProductSubcategoryClientResponseModel value)
		{
			this.ProductSubcategoryIDNavigation = value;
		}

		[JsonProperty]
		public ApiUnitMeasureClientResponseModel SizeUnitMeasureCodeNavigation { get; private set; }

		public void SetSizeUnitMeasureCodeNavigation(ApiUnitMeasureClientResponseModel value)
		{
			this.SizeUnitMeasureCodeNavigation = value;
		}

		[JsonProperty]
		public ApiUnitMeasureClientResponseModel WeightUnitMeasureCodeNavigation { get; private set; }

		public void SetWeightUnitMeasureCodeNavigation(ApiUnitMeasureClientResponseModel value)
		{
			this.WeightUnitMeasureCodeNavigation = value;
		}

		[JsonProperty]
		public string ReservedClass { get; private set; }

		[JsonProperty]
		public string Color { get; private set; }

		[JsonProperty]
		public int DaysToManufacture { get; private set; }

		[JsonProperty]
		public DateTime? DiscontinuedDate { get; private set; }

		[JsonProperty]
		public bool FinishedGoodsFlag { get; private set; }

		[JsonProperty]
		public decimal ListPrice { get; private set; }

		[JsonProperty]
		public bool MakeFlag { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductLine { get; private set; }

		[JsonProperty]
		public int? ProductModelID { get; private set; }

		[JsonProperty]
		public string ProductModelIDEntity { get; set; }

		[JsonProperty]
		public string ProductNumber { get; private set; }

		[JsonProperty]
		public int? ProductSubcategoryID { get; private set; }

		[JsonProperty]
		public string ProductSubcategoryIDEntity { get; set; }

		[JsonProperty]
		public short ReorderPoint { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public short SafetyStockLevel { get; private set; }

		[JsonProperty]
		public DateTime? SellEndDate { get; private set; }

		[JsonProperty]
		public DateTime SellStartDate { get; private set; }

		[JsonProperty]
		public string Size { get; private set; }

		[JsonProperty]
		public string SizeUnitMeasureCode { get; private set; }

		[JsonProperty]
		public string SizeUnitMeasureCodeEntity { get; set; }

		[JsonProperty]
		public decimal StandardCost { get; private set; }

		[JsonProperty]
		public string Style { get; private set; }

		[JsonProperty]
		public double? Weight { get; private set; }

		[JsonProperty]
		public string WeightUnitMeasureCode { get; private set; }

		[JsonProperty]
		public string WeightUnitMeasureCodeEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ff49acc2798231eaf7a021ca037e6bf9</Hash>
</Codenesium>*/