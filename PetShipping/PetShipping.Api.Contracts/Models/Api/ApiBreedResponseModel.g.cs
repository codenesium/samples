using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiBreedResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id;
			this.Name = name;
			this.SpeciesId = speciesId;

			this.SpeciesIdEntity = nameof(ApiResponse.Species);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>77a34f9d3c1ea50e9e01b16496b3fa95</Hash>
</Codenesium>*/