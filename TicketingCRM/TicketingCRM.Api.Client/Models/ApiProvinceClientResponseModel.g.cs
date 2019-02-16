using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiProvinceClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string name)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Name = name;

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
	}
}

/*<Codenesium>
    <Hash>93447d58bbc3d9e8aecd8ab4e806e1f0</Hash>
</Codenesium>*/