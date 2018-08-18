using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductRequestModel : AbstractApiRequestModel
	{
		public ApiProductRequestModel()
			: base()
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

		[JsonProperty]
		public string @Class { get; private set; }

		[JsonProperty]
		public string Color { get; private set; }

		[Required]
		[JsonProperty]
		public int DaysToManufacture { get; private set; }

		[JsonProperty]
		public DateTime? DiscontinuedDate { get; private set; }

		[Required]
		[JsonProperty]
		public bool FinishedGoodsFlag { get; private set; }

		[Required]
		[JsonProperty]
		public decimal ListPrice { get; private set; }

		[Required]
		[JsonProperty]
		public bool MakeFlag { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ProductLine { get; private set; }

		[JsonProperty]
		public int? ProductModelID { get; private set; }

		[Required]
		[JsonProperty]
		public string ProductNumber { get; private set; }

		[JsonProperty]
		public int? ProductSubcategoryID { get; private set; }

		[Required]
		[JsonProperty]
		public short ReorderPoint { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public short SafetyStockLevel { get; private set; }

		[JsonProperty]
		public DateTime? SellEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime SellStartDate { get; private set; }

		[JsonProperty]
		public string Size { get; private set; }

		[JsonProperty]
		public string SizeUnitMeasureCode { get; private set; }

		[Required]
		[JsonProperty]
		public decimal StandardCost { get; private set; }

		[JsonProperty]
		public string Style { get; private set; }

		[JsonProperty]
		public double? Weight { get; private set; }

		[JsonProperty]
		public string WeightUnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7b66f72ba1eb1b71976b059f2b6be866</Hash>
</Codenesium>*/