using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPetClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int breedId,
			int clientId,
			string name,
			int weight)
		{
			this.Id = id;
			this.BreedId = breedId;
			this.ClientId = clientId;
			this.Name = name;
			this.Weight = weight;

			this.BreedIdEntity = nameof(ApiResponse.Breeds);
		}

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string BreedIdEntity { get; set; }

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Weight { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9d89cc8e4b63cf67b8ecb450c8f45fdb</Hash>
</Codenesium>*/