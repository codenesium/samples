using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
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
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>8587159b76cf95281c99ad36b5d7bdbc</Hash>
</Codenesium>*/