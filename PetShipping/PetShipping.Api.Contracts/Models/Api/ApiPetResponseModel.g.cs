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
			this.BreedId = breedId.ToInt();
			this.ClientId = clientId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Weight = weight.ToInt();

			this.BreedIdEntity = nameof(ApiResponse.Breeds);
			this.ClientIdEntity = nameof(ApiResponse.Clients);
		}

		public int BreedId { get; private set; }
		public string BreedIdEntity { get; set; }
		public int ClientId { get; private set; }
		public string ClientIdEntity { get; set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int Weight { get; private set; }

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
    <Hash>381c5aea7fbe80ed92b3b06cfb474a87</Hash>
</Codenesium>*/