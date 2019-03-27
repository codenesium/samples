using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiCountryRequirementServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCountryRequirementServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string details)
		{
			this.CountryId = countryId;
			this.Details = details;
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Details { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5f551ec8617b28e0496f662bd5e94125</Hash>
</Codenesium>*/