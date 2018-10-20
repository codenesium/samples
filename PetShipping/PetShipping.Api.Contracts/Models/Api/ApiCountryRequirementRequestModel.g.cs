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
		public int CountryId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Detail { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>6555773dd6d4c73c002bf942de8edf04</Hash>
</Codenesium>*/