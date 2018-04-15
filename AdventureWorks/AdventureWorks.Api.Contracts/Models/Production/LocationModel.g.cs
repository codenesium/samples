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
			string name,
			decimal costRate,
			decimal availability,
			DateTime modifiedDate)
		{
			this.Name = name.ToString();
			this.CostRate = costRate.ToDecimal();
			this.Availability = availability.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
    <Hash>8278db23558218b004ea1a447bed089b</Hash>
</Codenesium>*/