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
			string details)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Details = details;
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
		public string Details { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b34cc98d1998a6078c560992190eaf4b</Hash>
</Codenesium>*/