using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiBreedResponseModel: AbstractApiResponseModel
	{
		public ApiBreedResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>c5c05455aba3ebb1d068eb74b82c58dd</Hash>
</Codenesium>*/