using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductModel
	{
		public ProductModel()
		{}

		public ProductModel(
			string name,
			string productNumber,
			bool makeFlag,
			bool finishedGoodsFlag,
			string color,
			short safetyStockLevel,
			short reorderPoint,
			decimal standardCost,
			decimal listPrice,
			string size,
			string sizeUnitMeasureCode,
			string weightUnitMeasureCode,
			Nullable<decimal> weight,
			int daysToManufacture,
			string productLine,
			string @class,
			string style,
			Nullable<int> productSubcategoryID,
			Nullable<int> productModelID,
			DateTime sellStartDate,
			Nullable<DateTime> sellEndDate,
			Nullable<DateTime> discontinuedDate,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Name = name;
			this.ProductNumber = productNumber;
			this.MakeFlag = makeFlag;
			this.FinishedGoodsFlag = finishedGoodsFlag;
			this.Color = color;
			this.SafetyStockLevel = safetyStockLevel;
			this.ReorderPoint = reorderPoint;
			this.StandardCost = standardCost;
			this.ListPrice = listPrice;
			this.Size = size;
			this.SizeUnitMeasureCode = sizeUnitMeasureCode;
			this.WeightUnitMeasureCode = weightUnitMeasureCode;
			this.Weight = weight.ToNullableDecimal();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.ProductLine = productLine;
			this.@Class = @class;
			this.Style = style;
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ProductModelID = productModelID.ToNullableInt();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private string productNumber;

		[Required]
		public string ProductNumber
		{
			get
			{
				return this.productNumber;
			}

			set
			{
				this.productNumber = value;
			}
		}

		private bool makeFlag;

		[Required]
		public bool MakeFlag
		{
			get
			{
				return this.makeFlag;
			}

			set
			{
				this.makeFlag = value;
			}
		}

		private bool finishedGoodsFlag;

		[Required]
		public bool FinishedGoodsFlag
		{
			get
			{
				return this.finishedGoodsFlag;
			}

			set
			{
				this.finishedGoodsFlag = value;
			}
		}

		private string color;

		public string Color
		{
			get
			{
				return this.color.IsEmptyOrZeroOrNull() ? null : this.color;
			}

			set
			{
				this.color = value;
			}
		}

		private short safetyStockLevel;

		[Required]
		public short SafetyStockLevel
		{
			get
			{
				return this.safetyStockLevel;
			}

			set
			{
				this.safetyStockLevel = value;
			}
		}

		private short reorderPoint;

		[Required]
		public short ReorderPoint
		{
			get
			{
				return this.reorderPoint;
			}

			set
			{
				this.reorderPoint = value;
			}
		}

		private decimal standardCost;

		[Required]
		public decimal StandardCost
		{
			get
			{
				return this.standardCost;
			}

			set
			{
				this.standardCost = value;
			}
		}

		private decimal listPrice;

		[Required]
		public decimal ListPrice
		{
			get
			{
				return this.listPrice;
			}

			set
			{
				this.listPrice = value;
			}
		}

		private string size;

		public string Size
		{
			get
			{
				return this.size.IsEmptyOrZeroOrNull() ? null : this.size;
			}

			set
			{
				this.size = value;
			}
		}

		private string sizeUnitMeasureCode;

		public string SizeUnitMeasureCode
		{
			get
			{
				return this.sizeUnitMeasureCode.IsEmptyOrZeroOrNull() ? null : this.sizeUnitMeasureCode;
			}

			set
			{
				this.sizeUnitMeasureCode = value;
			}
		}

		private string weightUnitMeasureCode;

		public string WeightUnitMeasureCode
		{
			get
			{
				return this.weightUnitMeasureCode.IsEmptyOrZeroOrNull() ? null : this.weightUnitMeasureCode;
			}

			set
			{
				this.weightUnitMeasureCode = value;
			}
		}

		private Nullable<decimal> weight;

		public Nullable<decimal> Weight
		{
			get
			{
				return this.weight.IsEmptyOrZeroOrNull() ? null : this.weight;
			}

			set
			{
				this.weight = value;
			}
		}

		private int daysToManufacture;

		[Required]
		public int DaysToManufacture
		{
			get
			{
				return this.daysToManufacture;
			}

			set
			{
				this.daysToManufacture = value;
			}
		}

		private string productLine;

		public string ProductLine
		{
			get
			{
				return this.productLine.IsEmptyOrZeroOrNull() ? null : this.productLine;
			}

			set
			{
				this.productLine = value;
			}
		}

		private string @class;

		public string @Class
		{
			get
			{
				return this.@class.IsEmptyOrZeroOrNull() ? null : this.@class;
			}

			set
			{
				this.@class = value;
			}
		}

		private string style;

		public string Style
		{
			get
			{
				return this.style.IsEmptyOrZeroOrNull() ? null : this.style;
			}

			set
			{
				this.style = value;
			}
		}

		private Nullable<int> productSubcategoryID;

		public Nullable<int> ProductSubcategoryID
		{
			get
			{
				return this.productSubcategoryID.IsEmptyOrZeroOrNull() ? null : this.productSubcategoryID;
			}

			set
			{
				this.productSubcategoryID = value;
			}
		}

		private Nullable<int> productModelID;

		public Nullable<int> ProductModelID
		{
			get
			{
				return this.productModelID.IsEmptyOrZeroOrNull() ? null : this.productModelID;
			}

			set
			{
				this.productModelID = value;
			}
		}

		private DateTime sellStartDate;

		[Required]
		public DateTime SellStartDate
		{
			get
			{
				return this.sellStartDate;
			}

			set
			{
				this.sellStartDate = value;
			}
		}

		private Nullable<DateTime> sellEndDate;

		public Nullable<DateTime> SellEndDate
		{
			get
			{
				return this.sellEndDate.IsEmptyOrZeroOrNull() ? null : this.sellEndDate;
			}

			set
			{
				this.sellEndDate = value;
			}
		}

		private Nullable<DateTime> discontinuedDate;

		public Nullable<DateTime> DiscontinuedDate
		{
			get
			{
				return this.discontinuedDate.IsEmptyOrZeroOrNull() ? null : this.discontinuedDate;
			}

			set
			{
				this.discontinuedDate = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b0b2c5b50ef27cb4134d5f02197685bc</Hash>
</Codenesium>*/