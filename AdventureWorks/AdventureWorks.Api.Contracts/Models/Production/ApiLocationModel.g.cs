using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiLocationModel: AbstractModel
	{
		public ApiLocationModel() : base()
		{}

		public ApiLocationModel(
			decimal availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
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
    <Hash>119dd381074d63e0d6e38c31cfd5f0a4</Hash>
</Codenesium>*/