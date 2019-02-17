using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
	public partial class ApiBreedServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiBreedServerRequestModel()
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
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>72330c6459432dbdb6e84476960cd536</Hash>
</Codenesium>*/