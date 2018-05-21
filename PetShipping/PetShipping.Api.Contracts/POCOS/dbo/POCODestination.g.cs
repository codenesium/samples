using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCODestination: AbstractPOCO
	{
		public POCODestination() : base()
		{}

		public POCODestination(
			int countryId,
			int id,
			string name,
			int order)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();

			this.CountryId = new ReferenceEntity<int>(countryId,
			                                          nameof(ApiResponse.Countries));
		}

		public ReferenceEntity<int> CountryId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryIdValue { get; set; } = true;

		public bool ShouldSerializeCountryId()
		{
			return this.ShouldSerializeCountryIdValue;
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
		public bool ShouldSerializeOrderValue { get; set; } = true;

		public bool ShouldSerializeOrder()
		{
			return this.ShouldSerializeOrderValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeOrderValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c4504b267fd1c7cc182b01ea4c1e9875</Hash>
</Codenesium>*/