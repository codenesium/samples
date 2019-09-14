using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPetServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string BreedIdEntity { get; private set; } = RouteConstants.Breeds;

		[JsonProperty]
		public ApiBreedServerResponseModel BreedIdNavigation { get; private set; }

		public void SetBreedIdNavigation(ApiBreedServerResponseModel value)
		{
			this.BreedIdNavigation = value;
		}

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
    <Hash>a5b74893bfd94b4293d6283963811687</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/