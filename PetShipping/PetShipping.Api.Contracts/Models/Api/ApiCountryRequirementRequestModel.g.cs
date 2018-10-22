using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public string Detail { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f3752b4ea9d8a91ee19c4c3dfc84a1aa</Hash>
</Codenesium>*/