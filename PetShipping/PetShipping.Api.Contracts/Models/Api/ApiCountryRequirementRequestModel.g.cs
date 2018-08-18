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
			string details)
		{
			this.CountryId = countryId;
			this.Details = details;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Details { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b5a9cb39c0d6bb6286efeb0c861a63e7</Hash>
</Codenesium>*/