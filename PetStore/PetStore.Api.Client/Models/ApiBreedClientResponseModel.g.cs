using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiBreedClientResponseModel : AbstractApiClientResponseModel
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

		[JsonProperty]
		public ApiSpeciesClientResponseModel SpeciesIdNavigation { get; private set; }

		public void SetSpeciesIdNavigation(ApiSpeciesClientResponseModel value)
		{
			this.SpeciesIdNavigation = value;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>d02363fa22796ae3f8aef3bb0a7c197a</Hash>
</Codenesium>*/