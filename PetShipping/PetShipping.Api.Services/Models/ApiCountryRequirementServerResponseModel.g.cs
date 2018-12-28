using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiCountryRequirementServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string detail)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Detail = detail;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string CountryIdEntity { get; private set; } = RouteConstants.Countries;

		[JsonProperty]
		public string Detail { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>89df1802c2b8f6bd95ccebe60babe1c3</Hash>
</Codenesium>*/