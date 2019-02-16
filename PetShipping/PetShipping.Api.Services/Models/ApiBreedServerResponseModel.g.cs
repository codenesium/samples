using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiBreedServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id;
			this.Name = name;
			this.SpeciesId = speciesId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; private set; } = RouteConstants.Species;

		[JsonProperty]
		public ApiSpeciesServerResponseModel SpeciesIdNavigation { get; private set; }

		public void SetSpeciesIdNavigation(ApiSpeciesServerResponseModel value)
		{
			this.SpeciesIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>6b90b3baf5c4b7c56f23aca297f8b326</Hash>
</Codenesium>*/