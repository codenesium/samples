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
		public ApiCountryServerResponseModel CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(ApiCountryServerResponseModel value)
		{
			this.CountryIdNavigation = value;
		}

		[JsonProperty]
		public string Detail { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>90f468c273ca85b326c7461539f24303</Hash>
</Codenesium>*/