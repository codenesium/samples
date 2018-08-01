using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string details)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Details = details;

			this.CountryIdEntity = nameof(ApiResponse.Countries);
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string CountryIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public string Details { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>46c008d248d2f9139841c512575da173</Hash>
</Codenesium>*/