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

		public SpecialOfferModel(POCOSpecialOffer poco)
		{
			this.Description = poco.Description;
			this.DiscountPct = poco.DiscountPct;
			this.Type = poco.Type;
			this.Category = poco.Category;
			this.StartDate = poco.StartDate.ToDateTime();
			this.EndDate = poco.EndDate.ToDateTime();
			this.MinQty = poco.MinQty.ToInt();
			this.MaxQty = poco.MaxQty.ToNullableInt();
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
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
    <Hash>17341c10dcb5065a2cbfed6d4a904b2e</Hash>
</Codenesium>*/