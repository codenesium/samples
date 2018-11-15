using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiPetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPetClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;
			this.SpeciesId = speciesId;
		}

		[JsonProperty]
		public DateTime AcquiredDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int BreedId { get; private set; }

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public int PenId { get; private set; }

		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);

		[JsonProperty]
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>42712b1f57aede626a0a038c68ef6ae0</Hash>
</Codenesium>*/