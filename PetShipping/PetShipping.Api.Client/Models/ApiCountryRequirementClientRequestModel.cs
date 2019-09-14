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
			string details)
		{
			this.CountryId = countryId;
			this.Details = details;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Details { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>0d92a546ab5db2251322c68836b9ff01</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/