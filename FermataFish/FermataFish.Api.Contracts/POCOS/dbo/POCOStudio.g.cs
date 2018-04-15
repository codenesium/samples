using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOStudio
	{
		public POCOStudio()
		{}

		public POCOStudio(
			int id,
			string name,
			string website,
			string address1,
			string address2,
			string city,
			int stateId,
			string zip)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.Website = website.ToString();
			this.Address1 = address1.ToString();
			this.Address2 = address2.ToString();
			this.City = city.ToString();
			this.Zip = zip.ToString();

			this.StateId = new ReferenceEntity<int>(stateId,
			                                        nameof(ApiResponse.States));
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Website { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public ReferenceEntity<int> StateId { get; set; }
		public string Zip { get; set; }

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
		public bool ShouldSerializeWebsiteValue { get; set; } = true;

		public bool ShouldSerializeWebsite()
		{
			return this.ShouldSerializeWebsiteValue;
		}

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
		public bool ShouldSerializeStateIdValue { get; set; } = true;

		public bool ShouldSerializeStateId()
		{
			return this.ShouldSerializeStateIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeZipValue { get; set; } = true;

		public bool ShouldSerializeZip()
		{
			return this.ShouldSerializeZipValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeWebsiteValue = false;
			this.ShouldSerializeAddress1Value = false;
			this.ShouldSerializeAddress2Value = false;
			this.ShouldSerializeCityValue = false;
			this.ShouldSerializeStateIdValue = false;
			this.ShouldSerializeZipValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>15ae8851956d85e6f4e6a33e723cdbb7</Hash>
</Codenesium>*/