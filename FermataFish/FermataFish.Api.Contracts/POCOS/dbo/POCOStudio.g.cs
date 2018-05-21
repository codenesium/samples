using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOStudio: AbstractPOCO
	{
		public POCOStudio() : base()
		{}

		public POCOStudio(
			string address1,
			string address2,
			string city,
			int id,
			string name,
			int stateId,
			string website,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id.ToInt();
			this.Name = name;
			this.Website = website;
			this.Zip = zip;

			this.StateId = new ReferenceEntity<int>(stateId,
			                                        nameof(ApiResponse.States));
		}

		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> StateId { get; set; }
		public string Website { get; set; }
		public string Zip { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAddress1Value { get; set; } = true;

		public bool ShouldSerializeAddress1()
		{
			return this.ShouldSerializeAddress1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddress2Value { get; set; } = true;

		public bool ShouldSerializeAddress2()
		{
			return this.ShouldSerializeAddress2Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeCityValue { get; set; } = true;

		public bool ShouldSerializeCity()
		{
			return this.ShouldSerializeCityValue;
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
		public bool ShouldSerializeStateIdValue { get; set; } = true;

		public bool ShouldSerializeStateId()
		{
			return this.ShouldSerializeStateIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeWebsiteValue { get; set; } = true;

		public bool ShouldSerializeWebsite()
		{
			return this.ShouldSerializeWebsiteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeZipValue { get; set; } = true;

		public bool ShouldSerializeZip()
		{
			return this.ShouldSerializeZipValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAddress1Value = false;
			this.ShouldSerializeAddress2Value = false;
			this.ShouldSerializeCityValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeStateIdValue = false;
			this.ShouldSerializeWebsiteValue = false;
			this.ShouldSerializeZipValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>025d0b56e64e05d3c9d627f2bf4af1ed</Hash>
</Codenesium>*/