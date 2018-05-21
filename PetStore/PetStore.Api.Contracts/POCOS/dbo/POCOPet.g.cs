using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class POCOPet: AbstractPOCO
	{
		public POCOPet() : base()
		{}

		public POCOPet(
			DateTime acquiredDate,
			int breedId,
			string description,
			int id,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate.ToDateTime();
			this.Description = description;
			this.Id = id.ToInt();
			this.Price = price.ToDecimal();

			this.BreedId = new ReferenceEntity<int>(breedId,
			                                        nameof(ApiResponse.Breeds));
			this.PenId = new ReferenceEntity<int>(penId,
			                                      nameof(ApiResponse.Pens));
			this.SpeciesId = new ReferenceEntity<int>(speciesId,
			                                          nameof(ApiResponse.Species));
		}

		public DateTime AcquiredDate { get; set; }
		public ReferenceEntity<int> BreedId { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> PenId { get; set; }
		public decimal Price { get; set; }
		public ReferenceEntity<int> SpeciesId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAcquiredDateValue { get; set; } = true;

		public bool ShouldSerializeAcquiredDate()
		{
			return this.ShouldSerializeAcquiredDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBreedIdValue { get; set; } = true;

		public bool ShouldSerializeBreedId()
		{
			return this.ShouldSerializeBreedIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePenIdValue { get; set; } = true;

		public bool ShouldSerializePenId()
		{
			return this.ShouldSerializePenIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePriceValue { get; set; } = true;

		public bool ShouldSerializePrice()
		{
			return this.ShouldSerializePriceValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpeciesIdValue { get; set; } = true;

		public bool ShouldSerializeSpeciesId()
		{
			return this.ShouldSerializeSpeciesIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAcquiredDateValue = false;
			this.ShouldSerializeBreedIdValue = false;
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePenIdValue = false;
			this.ShouldSerializePriceValue = false;
			this.ShouldSerializeSpeciesIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d6f04f050e994a9a02b3d36d1c1b83e3</Hash>
</Codenesium>*/