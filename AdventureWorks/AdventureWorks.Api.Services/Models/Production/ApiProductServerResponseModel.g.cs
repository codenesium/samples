using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductServerResponseModel : AbstractApiServerResponseModel
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
		}

		[Required]
		[JsonProperty]
		public string ReservedClass { get; private set; }

		[Required]
		[JsonProperty]
		public string Color { get; private set; }

		[JsonProperty]
		public int DaysToManufacture { get; private set; }

		[Required]
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

		[Required]
		[JsonProperty]
		public string ProductLine { get; private set; }

		[Required]
		[JsonProperty]
		public int? ProductModelID { get; private set; }

		[JsonProperty]
		public string ProductModelIDEntity { get; private set; } = RouteConstants.ProductModels;

		[JsonProperty]
		public ApiProductModelServerResponseModel ProductModelIDNavigation { get; private set; }

		public void SetProductModelIDNavigation(ApiProductModelServerResponseModel value)
		{
			this.ProductModelIDNavigation = value;
		}

		[JsonProperty]
		public string ProductNumber { get; private set; }

		[Required]
		[JsonProperty]
		public int? ProductSubcategoryID { get; private set; }

		[JsonProperty]
		public string ProductSubcategoryIDEntity { get; private set; } = RouteConstants.ProductSubcategories;

		[JsonProperty]
		public ApiProductSubcategoryServerResponseModel ProductSubcategoryIDNavigation { get; private set; }

		public void SetProductSubcategoryIDNavigation(ApiProductSubcategoryServerResponseModel value)
		{
			this.ProductSubcategoryIDNavigation = value;
		}

		[JsonProperty]
		public short ReorderPoint { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public short SafetyStockLevel { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? SellEndDate { get; private set; }

		[JsonProperty]
		public DateTime SellStartDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Size { get; private set; }

		[Required]
		[JsonProperty]
		public string SizeUnitMeasureCode { get; private set; }

		[JsonProperty]
		public string SizeUnitMeasureCodeEntity { get; private set; } = RouteConstants.UnitMeasures;

		[JsonProperty]
		public ApiUnitMeasureServerResponseModel SizeUnitMeasureCodeNavigation { get; private set; }

		public void SetSizeUnitMeasureCodeNavigation(ApiUnitMeasureServerResponseModel value)
		{
			this.SizeUnitMeasureCodeNavigation = value;
		}

		[JsonProperty]
		public decimal StandardCost { get; private set; }

		[Required]
		[JsonProperty]
		public string Style { get; private set; }

		[Required]
		[JsonProperty]
		public double? Weight { get; private set; }

		[Required]
		[JsonProperty]
		public string WeightUnitMeasureCode { get; private set; }

		[JsonProperty]
		public string WeightUnitMeasureCodeEntity { get; private set; } = RouteConstants.UnitMeasures;

		[JsonProperty]
		public ApiUnitMeasureServerResponseModel WeightUnitMeasureCodeNavigation { get; private set; }

		public void SetWeightUnitMeasureCodeNavigation(ApiUnitMeasureServerResponseModel value)
		{
			this.WeightUnitMeasureCodeNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>dfc86f04a4ee34fe572baa79f3af195e</Hash>
</Codenesium>*/