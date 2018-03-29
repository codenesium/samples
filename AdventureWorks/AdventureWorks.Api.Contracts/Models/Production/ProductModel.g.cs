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

		public ProductModel(string name,
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

		public ProductModel(POCOProduct poco)
		{
			this.Name = poco.Name;
			this.ProductNumber = poco.ProductNumber;
			this.MakeFlag = poco.MakeFlag;
			this.FinishedGoodsFlag = poco.FinishedGoodsFlag;
			this.Color = poco.Color;
			this.SafetyStockLevel = poco.SafetyStockLevel;
			this.ReorderPoint = poco.ReorderPoint;
			this.StandardCost = poco.StandardCost;
			this.ListPrice = poco.ListPrice;
			this.Size = poco.Size;
			this.Weight = poco.Weight.ToNullableDecimal();
			this.DaysToManufacture = poco.DaysToManufacture.ToInt();
			this.ProductLine = poco.ProductLine;
			this.@Class = poco.@Class;
			this.Style = poco.Style;
			this.SellStartDate = poco.SellStartDate.ToDateTime();
			this.SellEndDate = poco.SellEndDate.ToNullableDateTime();
			this.DiscontinuedDate = poco.DiscontinuedDate.ToNullableDateTime();
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.SizeUnitMeasureCode = poco.SizeUnitMeasureCode.Value.ToString();
			this.WeightUnitMeasureCode = poco.WeightUnitMeasureCode.Value.ToString();
			this.ProductSubcategoryID = poco.ProductSubcategoryID.Value.ToInt();
			this.ProductModelID = poco.ProductModelID.Value.ToInt();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string _productNumber;
		[Required]
		public string ProductNumber
		{
			get
			{
				return _productNumber;
			}
			set
			{
				this._productNumber = value;
			}
		}

		private bool _makeFlag;
		[Required]
		public bool MakeFlag
		{
			get
			{
				return _makeFlag;
			}
			set
			{
				this._makeFlag = value;
			}
		}

		private bool _finishedGoodsFlag;
		[Required]
		public bool FinishedGoodsFlag
		{
			get
			{
				return _finishedGoodsFlag;
			}
			set
			{
				this._finishedGoodsFlag = value;
			}
		}

		private string _color;
		public string Color
		{
			get
			{
				return _color.IsEmptyOrZeroOrNull() ? null : _color;
			}
			set
			{
				this._color = value;
			}
		}

		private short _safetyStockLevel;
		[Required]
		public short SafetyStockLevel
		{
			get
			{
				return _safetyStockLevel;
			}
			set
			{
				this._safetyStockLevel = value;
			}
		}

		private short _reorderPoint;
		[Required]
		public short ReorderPoint
		{
			get
			{
				return _reorderPoint;
			}
			set
			{
				this._reorderPoint = value;
			}
		}

		private decimal _standardCost;
		[Required]
		public decimal StandardCost
		{
			get
			{
				return _standardCost;
			}
			set
			{
				this._standardCost = value;
			}
		}

		private decimal _listPrice;
		[Required]
		public decimal ListPrice
		{
			get
			{
				return _listPrice;
			}
			set
			{
				this._listPrice = value;
			}
		}

		private string _size;
		public string Size
		{
			get
			{
				return _size.IsEmptyOrZeroOrNull() ? null : _size;
			}
			set
			{
				this._size = value;
			}
		}

		private string _sizeUnitMeasureCode;
		public string SizeUnitMeasureCode
		{
			get
			{
				return _sizeUnitMeasureCode.IsEmptyOrZeroOrNull() ? null : _sizeUnitMeasureCode;
			}
			set
			{
				this._sizeUnitMeasureCode = value;
			}
		}

		private string _weightUnitMeasureCode;
		public string WeightUnitMeasureCode
		{
			get
			{
				return _weightUnitMeasureCode.IsEmptyOrZeroOrNull() ? null : _weightUnitMeasureCode;
			}
			set
			{
				this._weightUnitMeasureCode = value;
			}
		}

		private Nullable<decimal> _weight;
		public Nullable<decimal> Weight
		{
			get
			{
				return _weight.IsEmptyOrZeroOrNull() ? null : _weight;
			}
			set
			{
				this._weight = value;
			}
		}

		private int _daysToManufacture;
		[Required]
		public int DaysToManufacture
		{
			get
			{
				return _daysToManufacture;
			}
			set
			{
				this._daysToManufacture = value;
			}
		}

		private string _productLine;
		public string ProductLine
		{
			get
			{
				return _productLine.IsEmptyOrZeroOrNull() ? null : _productLine;
			}
			set
			{
				this._productLine = value;
			}
		}

		private string @class;
		public string @Class
		{
			get
			{
				return @class.IsEmptyOrZeroOrNull() ? null : @class;
			}
			set
			{
				this.@class = value;
			}
		}

		private string _style;
		public string Style
		{
			get
			{
				return _style.IsEmptyOrZeroOrNull() ? null : _style;
			}
			set
			{
				this._style = value;
			}
		}

		private Nullable<int> _productSubcategoryID;
		public Nullable<int> ProductSubcategoryID
		{
			get
			{
				return _productSubcategoryID.IsEmptyOrZeroOrNull() ? null : _productSubcategoryID;
			}
			set
			{
				this._productSubcategoryID = value;
			}
		}

		private Nullable<int> _productModelID;
		public Nullable<int> ProductModelID
		{
			get
			{
				return _productModelID.IsEmptyOrZeroOrNull() ? null : _productModelID;
			}
			set
			{
				this._productModelID = value;
			}
		}

		private DateTime _sellStartDate;
		[Required]
		public DateTime SellStartDate
		{
			get
			{
				return _sellStartDate;
			}
			set
			{
				this._sellStartDate = value;
			}
		}

		private Nullable<DateTime> _sellEndDate;
		public Nullable<DateTime> SellEndDate
		{
			get
			{
				return _sellEndDate.IsEmptyOrZeroOrNull() ? null : _sellEndDate;
			}
			set
			{
				this._sellEndDate = value;
			}
		}

		private Nullable<DateTime> _discontinuedDate;
		public Nullable<DateTime> DiscontinuedDate
		{
			get
			{
				return _discontinuedDate.IsEmptyOrZeroOrNull() ? null : _discontinuedDate;
			}
			set
			{
				this._discontinuedDate = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>285486c89c227ebdc6e8787b902ff870</Hash>
</Codenesium>*/