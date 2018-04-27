using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class CountryRequirementModel
	{
		public CountryRequirementModel()
		{}

		public CountryRequirementModel(
			int countryId,
			string details)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details.ToString();
		}

		private int countryId;

		[Required]
		public int CountryId
		{
			get
			{
				return this.countryId;
			}

			set
			{
				this.countryId = value;
			}
		}

		private string details;

		[Required]
		public string Details
		{
			get
			{
				return this.details;
			}

			set
			{
				this.details = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>0fb4f4946577634f74ab76c19c730fa0</Hash>
</Codenesium>*/