using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementRequestModel: AbstractApiRequestModel
	{
		public ApiCountryRequirementRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>49be9ff23a6db22fa89f824d799b1644</Hash>
</Codenesium>*/