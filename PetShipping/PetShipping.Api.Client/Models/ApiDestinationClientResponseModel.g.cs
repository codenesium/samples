using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiDestinationClientResponseModel : AbstractApiClientResponseModel
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

			this.CountryIdEntity = nameof(ApiResponse.Countries);
		}

		[JsonProperty]
		public ApiCountryClientResponseModel CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(ApiCountryClientResponseModel value)
		{
			this.CountryIdNavigation = value;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string CountryIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>70cd351d57bc4d89f1b377b9c2fad298</Hash>
</Codenesium>*/