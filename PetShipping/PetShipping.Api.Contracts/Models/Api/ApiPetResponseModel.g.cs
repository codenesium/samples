using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPetResponseModel : AbstractApiResponseModel
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
			this.ClientIdEntity = nameof(ApiResponse.Clients);
		}

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string BreedIdEntity { get; set; }

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public string ClientIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Weight { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7c157d1141b25454df2550515db79b54</Hash>
</Codenesium>*/