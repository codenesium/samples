using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
		public string Color { get; private set; } = default(string);

		[JsonProperty]
		public int DaysToManufacture { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? DiscontinuedDate { get; private set; } = null;

		[JsonProperty]
		public bool FinishedGoodsFlag { get; private set; } = default(bool);

		[JsonProperty]
		public decimal ListPrice { get; private set; } = default(decimal);

		[JsonProperty]
		public bool MakeFlag { get; private set; } = default(bool);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string ProductLine { get; private set; } = default(string);

		[JsonProperty]
		public int? ProductModelID { get; private set; } = default(int);

		[JsonProperty]
		public string ProductNumber { get; private set; } = default(string);

		[JsonProperty]
		public int? ProductSubcategoryID { get; private set; } = default(int);

		[JsonProperty]
		public short ReorderPoint { get; private set; } = default(short);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public short SafetyStockLevel { get; private set; } = default(short);

		[JsonProperty]
		public DateTime? SellEndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime SellStartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Size { get; private set; } = default(string);

		[JsonProperty]
		public string SizeUnitMeasureCode { get; private set; } = default(string);

		[JsonProperty]
		public decimal StandardCost { get; private set; } = default(decimal);

		[JsonProperty]
		public string Style { get; private set; } = default(string);

		[JsonProperty]
		public double? Weight { get; private set; } = default(double);

		[JsonProperty]
		public string WeightUnitMeasureCode { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>e1cdfbb90fbf72bb49053f7373afb12c</Hash>
</Codenesium>*/