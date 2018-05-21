using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOBreed: AbstractPOCO
	{
		public POCOBreed() : base()
		{}

		public POCOBreed(
			int id,
			string name,
			int speciesId)
		{
			this.Id = id.ToInt();
			this.Name = name;

			this.SpeciesId = new ReferenceEntity<int>(speciesId,
			                                          nameof(ApiResponse.Species));
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> SpeciesId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpeciesIdValue { get; set; } = true;

		public bool ShouldSerializeSpeciesId()
		{
			return this.ShouldSerializeSpeciesIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeSpeciesIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>78e73874c1a0d0ac4c8343a3bab5e427</Hash>
</Codenesium>*/