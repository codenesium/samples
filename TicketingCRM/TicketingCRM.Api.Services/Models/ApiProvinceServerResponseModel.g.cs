using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiProvinceServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string name)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>010b9b9f065b3429b0163aad1175b3c0</Hash>
</Codenesium>*/