using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SpecialOfferModel
	{
		public SpecialOfferModel()
		{}
		public SpecialOfferModel(string description,
		                         decimal discountPct,
		                         string type,
		                         string category,
		                         DateTime startDate,
		                         DateTime endDate,
		                         int minQty,
		                         Nullable<int> maxQty,
		                         Guid rowguid,
		                         DateTime modifiedDate)
		{
			this.Description = description;
			this.DiscountPct = discountPct;
			this.Type = type;
			this.Category = category;
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToDateTime();
			this.MinQty = minQty.ToInt();
			this.MaxQty = maxQty.ToNullableInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _description;
		[Required]
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				this._description = value;
			}
		}

		private decimal _discountPct;
		[Required]
		public decimal DiscountPct
		{
			get
			{
				return _discountPct;
			}
			set
			{
				this._discountPct = value;
			}
		}

		private string _type;
		[Required]
		public string Type
		{
			get
			{
				return _type;
			}
			set
			{
				this._type = value;
			}
		}

		private string _category;
		[Required]
		public string Category
		{
			get
			{
				return _category;
			}
			set
			{
				this._category = value;
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

		private DateTime _endDate;
		[Required]
		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				this._endDate = value;
			}
		}

		private int _minQty;
		[Required]
		public int MinQty
		{
			get
			{
				return _minQty;
			}
			set
			{
				this._minQty = value;
			}
		}

		private Nullable<int> _maxQty;
		public Nullable<int> MaxQty
		{
			get
			{
				return _maxQty.IsEmptyOrZeroOrNull() ? null : _maxQty;
			}
			set
			{
				this._maxQty = value;
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
    <Hash>6210bf7a1cc2f12640dc321264e2cb7d</Hash>
</Codenesium>*/