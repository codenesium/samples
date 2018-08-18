using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiDestinationResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string CountryIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>355619184944ad17da861cf63517d321</Hash>
</Codenesium>*/