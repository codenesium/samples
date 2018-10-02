using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementRequestModel : AbstractApiRequestModel
	{
		public ApiCountryRequirementRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string detail)
		{
			this.CountryId = countryId;
			this.Detail = detail;
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Detail { get; private set; }
	}
}

/*<Codenesium>
    <Hash>950751c62fd529ad10c79b4d5edfd48c</Hash>
</Codenesium>*/