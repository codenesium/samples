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
			decimal price)
		{
			this.Id = id;
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;

			this.BreedIdEntity = nameof(ApiResponse.Breeds);

			this.PenIdEntity = nameof(ApiResponse.Pens);
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
	}
}

/*<Codenesium>
    <Hash>47a8982b46ff383608f2b7c9d8c7dc86</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/