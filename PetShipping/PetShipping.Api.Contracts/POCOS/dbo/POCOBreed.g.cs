using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOBreed
	{
		public POCOBreed()
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
    <Hash>881d2122891f1ee0c541a574a4638b8f</Hash>
</Codenesium>*/