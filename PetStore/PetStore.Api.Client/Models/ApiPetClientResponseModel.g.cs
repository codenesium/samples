using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiPetClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price,
			int speciesId)
		{
			this.Id = id;
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;
			this.SpeciesId = speciesId;

			this.BreedIdEntity = nameof(ApiResponse.Breeds);

			this.PenIdEntity = nameof(ApiResponse.Pens);

			this.SpeciesIdEntity = nameof(ApiResponse.Species);
		}

		[JsonProperty]
		public ApiBreedClientResponseModel BreedIdNavigation { get; private set; }

		public void SetBreedIdNavigation(ApiBreedClientResponseModel value)
		{
			this.BreedIdNavigation = value;
		}

		[JsonProperty]
		public ApiPenClientResponseModel PenIdNavigation { get; private set; }

		public void SetPenIdNavigation(ApiPenClientResponseModel value)
		{
			this.PenIdNavigation = value;
		}

		[JsonProperty]
		public ApiSpeciesClientResponseModel SpeciesIdNavigation { get; private set; }

		public void SetSpeciesIdNavigation(ApiSpeciesClientResponseModel value)
		{
			this.SpeciesIdNavigation = value;
		}

		[JsonProperty]
		public DateTime AcquiredDate { get; private set; }

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string BreedIdEntity { get; set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PenId { get; private set; }

		[JsonProperty]
		public string PenIdEntity { get; set; }

		[JsonProperty]
		public decimal Price { get; private set; }

		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>0afbb46218f806b5a4e3b59b50945127</Hash>
</Codenesium>*/