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

		[Required]
		[JsonProperty]
		public int BreedId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ClientId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int Weight { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>2ee0cc441897b8523aad5692e62b52b5</Hash>
</Codenesium>*/