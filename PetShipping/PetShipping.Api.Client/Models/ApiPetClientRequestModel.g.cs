using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPetClientRequestModel()
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
		public int ClientId { get; private set; } = default(int);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int Weight { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>30d6fed51c823e1081ff219b314a991a</Hash>
</Codenesium>*/