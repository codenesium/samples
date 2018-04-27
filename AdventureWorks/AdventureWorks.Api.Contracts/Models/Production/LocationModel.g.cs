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

		public LocationModel(
			decimal availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
		}

		private decimal availability;

		[Required]
		public decimal Availability
		{
			get
			{
				return this.availability;
			}

			set
			{
				this.availability = value;
			}
		}

		private decimal costRate;

		[Required]
		public decimal CostRate
		{
			get
			{
				return this.costRate;
			}

			set
			{
				this.costRate = value;
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
	}
}

/*<Codenesium>
    <Hash>6cae1fafcb9d4badc31d359745982b46</Hash>
</Codenesium>*/