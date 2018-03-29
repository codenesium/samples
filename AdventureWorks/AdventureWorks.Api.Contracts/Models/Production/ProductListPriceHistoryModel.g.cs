using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductListPriceHistoryModel
	{
		public ProductListPriceHistoryModel()
		{}

		public ProductListPriceHistoryModel(DateTime startDate,
		                                    Nullable<DateTime> endDate,
		                                    decimal listPrice,
		                                    DateTime modifiedDate)
		{
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.ListPrice = listPrice;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductListPriceHistoryModel(POCOProductListPriceHistory poco)
		{
			this.StartDate = poco.StartDate.ToDateTime();
			this.EndDate = poco.EndDate.ToNullableDateTime();
			this.ListPrice = poco.ListPrice;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
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
    <Hash>46497d00e390a16f3a95f6fa63133044</Hash>
</Codenesium>*/