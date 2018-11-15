using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPetServerRequestModel()
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
		public int BreedId { get; private set; }

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
    <Hash>26b7f59f582fe7ae670c4a5fa2a96427</Hash>
</Codenesium>*/