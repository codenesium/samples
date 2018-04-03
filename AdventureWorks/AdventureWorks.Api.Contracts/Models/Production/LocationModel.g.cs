using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class LocationModel
	{
		public LocationModel()
		{}
		public LocationModel(string name,
		                     decimal costRate,
		                     decimal availability,
		                     DateTime modifiedDate)
		{
			this.Name = name;
			this.CostRate = costRate;
			this.Availability = availability.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
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

		private decimal _costRate;
		[Required]
		public decimal CostRate
		{
			get
			{
				return _costRate;
			}
			set
			{
				this._costRate = value;
			}
		}

		private decimal _availability;
		[Required]
		public decimal Availability
		{
			get
			{
				return _availability;
			}
			set
			{
				this._availability = value;
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
    <Hash>b7a6229f0850bca2f4088fd842ad2d6c</Hash>
</Codenesium>*/