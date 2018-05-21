using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOCountryRequirement: AbstractPOCO
	{
		public POCOCountryRequirement() : base()
		{}

		public POCOCountryRequirement(
			int countryId,
			string details,
			int id)
		{
			this.Details = details;
			this.Id = id.ToInt();

			this.CountryId = new ReferenceEntity<int>(countryId,
			                                          nameof(ApiResponse.Countries));
		}

		public ReferenceEntity<int> CountryId { get; set; }
		public string Details { get; set; }
		public int Id { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryIdValue { get; set; } = true;

		public bool ShouldSerializeCountryId()
		{
			return this.ShouldSerializeCountryIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDetailsValue { get; set; } = true;

		public bool ShouldSerializeDetails()
		{
			return this.ShouldSerializeDetailsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryIdValue = false;
			this.ShouldSerializeDetailsValue = false;
			this.ShouldSerializeIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6e5e52d0a0ac928935ef5c5a0fcc4777</Hash>
</Codenesium>*/