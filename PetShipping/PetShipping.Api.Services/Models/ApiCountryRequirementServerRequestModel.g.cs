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
    <Hash>2445be8f5cd6e705e94884720c9a77b9</Hash>
</Codenesium>*/