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
		public string CountryIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>29553872c26cbab2cb2e89b0ad01aa9f</Hash>
</Codenesium>*/