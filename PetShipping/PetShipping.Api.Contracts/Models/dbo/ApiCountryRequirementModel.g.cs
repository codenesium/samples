using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementModel
	{
		public ApiCountryRequirementModel()
		{}

		public ApiCountryRequirementModel(
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
    <Hash>b87dbe11173f9290017b5cdc77341dd0</Hash>
</Codenesium>*/