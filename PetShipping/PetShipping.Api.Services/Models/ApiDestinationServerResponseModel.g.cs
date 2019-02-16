using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiDestinationServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string name,
			int order)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Name = name;
			this.Order = order;
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
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>10709dc58eed2d21f556ffbd93e3a161</Hash>
</Codenesium>*/