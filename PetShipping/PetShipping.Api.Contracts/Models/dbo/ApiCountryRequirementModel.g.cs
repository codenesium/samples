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
			this.Details = details;
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
    <Hash>28ac8a272900c3eaeee4c37e3989d357</Hash>
</Codenesium>*/