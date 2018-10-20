using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Contracts
{
	public partial class ApiPetRequestModel : AbstractApiRequestModel
	{
		public ApiPetRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime AcquiredDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int BreedId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PenId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int SpeciesId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>c3488abc0859b2ff0f6b6681d10c489c</Hash>
</Codenesium>*/