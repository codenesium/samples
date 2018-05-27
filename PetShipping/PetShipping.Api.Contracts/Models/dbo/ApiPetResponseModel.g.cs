using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPetResponseModel: AbstractApiResponseModel
	{
		public ApiPetResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>9f824c80c6822de3a44015ae8edfffbc</Hash>
</Codenesium>*/