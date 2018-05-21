using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOPet: AbstractPOCO
	{
		public POCOPet() : base()
		{}

		public POCOPet(
			int breedId,
			int clientId,
			int id,
			string name,
			int weight)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.Weight = weight.ToInt();

			this.BreedId = new ReferenceEntity<int>(breedId,
			                                        nameof(ApiResponse.Breeds));
			this.ClientId = new ReferenceEntity<int>(clientId,
			                                         nameof(ApiResponse.Clients));
		}

		public ReferenceEntity<int> BreedId { get; set; }
		public ReferenceEntity<int> ClientId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Weight { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBreedIdValue { get; set; } = true;

		public bool ShouldSerializeBreedId()
		{
			return this.ShouldSerializeBreedIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeClientIdValue { get; set; } = true;

		public bool ShouldSerializeClientId()
		{
			return this.ShouldSerializeClientIdValue;
		}

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
		public bool ShouldSerializeWeightValue { get; set; } = true;

		public bool ShouldSerializeWeight()
		{
			return this.ShouldSerializeWeightValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBreedIdValue = false;
			this.ShouldSerializeClientIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeWeightValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1c788eb8d7c060c0e1677cf5e53d1ae7</Hash>
</Codenesium>*/