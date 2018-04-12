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

		public SpecialOfferModel(
			string description,
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

		private string description;

		[Required]
		public string Description
		{
			get
			{
				return this.description;
			}

			set
			{
				this.description = value;
			}
		}

		private decimal discountPct;

		[Required]
		public decimal DiscountPct
		{
			get
			{
				return this.discountPct;
			}

			set
			{
				this.discountPct = value;
			}
		}

		private string type;

		[Required]
		public string Type
		{
			get
			{
				return this.type;
			}

			set
			{
				this.type = value;
			}
		}

		private string category;

		[Required]
		public string Category
		{
			get
			{
				return this.category;
			}

			set
			{
				this.category = value;
			}
		}

		private DateTime startDate;

		[Required]
		public DateTime StartDate
		{
			get
			{
				return this.startDate;
			}

			set
			{
				this.startDate = value;
			}
		}

		private DateTime endDate;

		[Required]
		public DateTime EndDate
		{
			get
			{
				return this.endDate;
			}

			set
			{
				this.endDate = value;
			}
		}

		private int minQty;

		[Required]
		public int MinQty
		{
			get
			{
				return this.minQty;
			}

			set
			{
				this.minQty = value;
			}
		}

		private Nullable<int> maxQty;

		public Nullable<int> MaxQty
		{
			get
			{
				return this.maxQty.IsEmptyOrZeroOrNull() ? null : this.maxQty;
			}

			set
			{
				this.maxQty = value;
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
    <Hash>be764182cb8778531ff4ce99966c563d</Hash>
</Codenesium>*/