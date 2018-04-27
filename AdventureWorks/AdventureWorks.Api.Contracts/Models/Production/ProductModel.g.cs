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
			this.@Class = @class.ToString();
			this.Color = color.ToString();
			this.DaysToManufacture = daysToManufacture.ToInt();
			this.DiscontinuedDate = discontinuedDate.ToNullableDateTime();
			this.FinishedGoodsFlag = finishedGoodsFlag.ToBoolean();
			this.ListPrice = listPrice.ToDecimal();
			this.MakeFlag = makeFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ProductLine = productLine.ToString();
			this.ProductModelID = productModelID.ToNullableInt();
			this.ProductNumber = productNumber.ToString();
			this.ProductSubcategoryID = productSubcategoryID.ToNullableInt();
			this.ReorderPoint = reorderPoint;
			this.Rowguid = rowguid.ToGuid();
			this.SafetyStockLevel = safetyStockLevel;
			this.SellEndDate = sellEndDate.ToNullableDateTime();
			this.SellStartDate = sellStartDate.ToDateTime();
			this.Size = size.ToString();
			this.SizeUnitMeasureCode = sizeUnitMeasureCode.ToString();
			this.StandardCost = standardCost.ToDecimal();
			this.Style = style.ToString();
			this.Weight = weight.ToNullableDecimal();
			this.WeightUnitMeasureCode = weightUnitMeasureCode.ToString();
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
	}
}

/*<Codenesium>
    <Hash>3160144d848975fa519975c0f2dbefb1</Hash>
</Codenesium>*/