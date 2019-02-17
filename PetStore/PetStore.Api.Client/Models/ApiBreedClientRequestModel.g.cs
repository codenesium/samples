using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiBreedClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBreedClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int speciesId)
		{
			this.Name = name;
			this.SpeciesId = speciesId;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>edc777257e890cd3fece52eaf4cad5d3</Hash>
</Codenesium>*/