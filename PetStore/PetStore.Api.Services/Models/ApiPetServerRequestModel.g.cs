using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
	public partial class ApiPetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPetServerRequestModel()
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
		public DateTime AcquiredDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int BreedId { get; private set; }

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PenId { get; private set; }

		[Required]
		[JsonProperty]
		public decimal Price { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>46af944a06e73146a80d807f481e7cb8</Hash>
</Codenesium>*/