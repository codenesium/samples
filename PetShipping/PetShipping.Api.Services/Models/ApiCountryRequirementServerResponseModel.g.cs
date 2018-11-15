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
		public string CountryIdEntity { get; set; }

		[JsonProperty]
		public string Detail { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9b599bee734c5fd00644f3710f2e27e6</Hash>
</Codenesium>*/