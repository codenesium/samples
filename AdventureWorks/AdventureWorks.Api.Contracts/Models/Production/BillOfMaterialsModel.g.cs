using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class BillOfMaterialsModel
	{
		public BillOfMaterialsModel()
		{}
		public BillOfMaterialsModel(Nullable<int> productAssemblyID,
		                            int componentID,
		                            DateTime startDate,
		                            Nullable<DateTime> endDate,
		                            string unitMeasureCode,
		                            short bOMLevel,
		                            decimal perAssemblyQty,
		                            DateTime modifiedDate)
		{
			this.ProductAssemblyID = productAssemblyID.ToNullableInt();
			this.ComponentID = componentID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.UnitMeasureCode = unitMeasureCode;
			this.BOMLevel = bOMLevel;
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<int> _productAssemblyID;
		public Nullable<int> ProductAssemblyID
		{
			get
			{
				return _productAssemblyID.IsEmptyOrZeroOrNull() ? null : _productAssemblyID;
			}
			set
			{
				this._productAssemblyID = value;
			}
		}

		private int _componentID;
		[Required]
		public int ComponentID
		{
			get
			{
				return _componentID;
			}
			set
			{
				this._componentID = value;
			}
		}

		private DateTime _startDate;
		[Required]
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				this._startDate = value;
			}
		}

		private Nullable<DateTime> _endDate;
		public Nullable<DateTime> EndDate
		{
			get
			{
				return _endDate.IsEmptyOrZeroOrNull() ? null : _endDate;
			}
			set
			{
				this._endDate = value;
			}
		}

		private string _unitMeasureCode;
		[Required]
		public string UnitMeasureCode
		{
			get
			{
				return _unitMeasureCode;
			}
			set
			{
				this._unitMeasureCode = value;
			}
		}

		private short _bOMLevel;
		[Required]
		public short BOMLevel
		{
			get
			{
				return _bOMLevel;
			}
			set
			{
				this._bOMLevel = value;
			}
		}

		private decimal _perAssemblyQty;
		[Required]
		public decimal PerAssemblyQty
		{
			get
			{
				return _perAssemblyQty;
			}
			set
			{
				this._perAssemblyQty = value;
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
    <Hash>c12066cd0477991e9bc784ea625e49de</Hash>
</Codenesium>*/