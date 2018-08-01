using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPetRequestModel : AbstractApiRequestModel
	{
		public ApiPetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int breedId,
			int clientId,
			string name,
			int weight)
		{
			this.BreedId = breedId;
			this.ClientId = clientId;
			this.Name = name;
			this.Weight = weight;
		}

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int Weight { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fd9d332dda50ada519cae96e0aaf6a59</Hash>
</Codenesium>*/