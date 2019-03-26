using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductServerRequestModel()
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

		[JsonProperty]
		public string ReservedClass { get; private set; } = default(string);

		[JsonProperty]
		public string Color { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int DaysToManufacture { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? DiscontinuedDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public bool FinishedGoodsFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public decimal ListPrice { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public bool MakeFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string ProductLine { get; private set; } = default(string);

		[JsonProperty]
		public int? ProductModelID { get; private set; }

		[Required]
		[JsonProperty]
		public string ProductNumber { get; private set; } = default(string);

		[JsonProperty]
		public int? ProductSubcategoryID { get; private set; }

		[Required]
		[JsonProperty]
		public short ReorderPoint { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public short SafetyStockLevel { get; private set; } = default(short);

		[JsonProperty]
		public DateTime? SellEndDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public DateTime SellStartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Size { get; private set; } = default(string);

		[JsonProperty]
		public string SizeUnitMeasureCode { get; private set; }

		[Required]
		[JsonProperty]
		public decimal StandardCost { get; private set; } = default(decimal);

		[JsonProperty]
		public string Style { get; private set; } = default(string);

		[JsonProperty]
		public double? Weight { get; private set; } = default(double);

		[JsonProperty]
		public string WeightUnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c79f43d833c21b5495a00960ddcc7741</Hash>
</Codenesium>*/