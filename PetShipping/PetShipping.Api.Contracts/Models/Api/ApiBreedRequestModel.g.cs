using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiBreedRequestModel : AbstractApiRequestModel
	{
		public ApiBreedRequestModel()
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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int SpeciesId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>5f8345a067b5b414c2cc1d517b8cf0e6</Hash>
</Codenesium>*/