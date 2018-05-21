using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementModel: AbstractModel
	{
		public ApiCountryRequirementModel() : base()
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
    <Hash>354d5323d7476d28b7d4665bb36b5d3b</Hash>
</Codenesium>*/