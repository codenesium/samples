using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductCostHistoryModel
	{
		public ProductCostHistoryModel()
		{}

		public ProductCostHistoryModel(DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               decimal standardCost,
		                               DateTime modifiedDate)
		{
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.StandardCost = standardCost;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductCostHistoryModel(POCOProductCostHistory poco)
		{
			this.StartDate = poco.StartDate.ToDateTime();
			this.EndDate = poco.EndDate.ToNullableDateTime();
			this.StandardCost = poco.StandardCost;
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
    <Hash>39ea9ae7c28940729a3b73fda8cdbbe3</Hash>
</Codenesium>*/