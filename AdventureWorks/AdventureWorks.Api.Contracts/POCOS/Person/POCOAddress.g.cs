using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAddress
	{
		public POCOAddress()
		{}

		public POCOAddress(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			int stateProvinceID,
			string postalCode,
			object spatialLocation,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.PostalCode = postalCode;
			this.SpatialLocation = spatialLocation;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.StateProvinceID = new ReferenceEntity<int>(stateProvinceID,
			                                                "StateProvince");
		}

		public int AddressID { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public ReferenceEntity<int> StateProvinceID { get; set; }
		public string PostalCode { get; set; }
		public object SpatialLocation { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAddressIDValue { get; set; } = true;

		public bool ShouldSerializeAddressID()
		{
			return this.ShouldSerializeAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressLine1Value { get; set; } = true;

		public bool ShouldSerializeAddressLine1()
		{
			return this.ShouldSerializeAddressLine1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressLine2Value { get; set; } = true;

		public bool ShouldSerializeAddressLine2()
		{
			return this.ShouldSerializeAddressLine2Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeCityValue { get; set; } = true;

		public bool ShouldSerializeCity()
		{
			return this.ShouldSerializeCityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePostalCodeValue { get; set; } = true;

		public bool ShouldSerializePostalCode()
		{
			return this.ShouldSerializePostalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpatialLocationValue { get; set; } = true;

		public bool ShouldSerializeSpatialLocation()
		{
			return this.ShouldSerializeSpatialLocationValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAddressIDValue = false;
			this.ShouldSerializeAddressLine1Value = false;
			this.ShouldSerializeAddressLine2Value = false;
			this.ShouldSerializeCityValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializePostalCodeValue = false;
			this.ShouldSerializeSpatialLocationValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3388e197e05ec1b73e00727ccf2e6a73</Hash>
</Codenesium>*/