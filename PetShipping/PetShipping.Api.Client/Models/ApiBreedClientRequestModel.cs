using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
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
    <Hash>ae9585aa849d70678977816f39533fd7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/