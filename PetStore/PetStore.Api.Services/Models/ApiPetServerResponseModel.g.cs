using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
	public partial class ApiPetServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price,
			int speciesId)
		{
			this.Id = id;
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;
			this.SpeciesId = speciesId;
		}

		[JsonProperty]
		public DateTime AcquiredDate { get; private set; }

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string BreedIdEntity { get; set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PenId { get; private set; }

		[JsonProperty]
		public string PenIdEntity { get; set; }

		[JsonProperty]
		public decimal Price { get; private set; }

		[JsonProperty]
		public int SpeciesId { get; private set; }

		[JsonProperty]
		public string SpeciesIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>d4c60a62adb2163669696809d3ea47ce</Hash>
</Codenesium>*/