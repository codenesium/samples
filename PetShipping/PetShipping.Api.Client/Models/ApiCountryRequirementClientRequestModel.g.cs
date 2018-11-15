using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCountryRequirementClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCountryRequirementClientRequestModel()
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

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Detail { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>69fa7f8a4b4703da5022897f7f92d049</Hash>
</Codenesium>*/