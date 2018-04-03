using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOAddress
	{
		public POCOAddress()
		{}

		public POCOAddress(int addressID,
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
			this.StateProvinceID = stateProvinceID.ToInt();
			this.PostalCode = postalCode;
			this.SpatialLocation = spatialLocation;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int AddressID {get; set;}
		public string AddressLine1 {get; set;}
		public string AddressLine2 {get; set;}
		public string City {get; set;}
		public int StateProvinceID {get; set;}
		public string PostalCode {get; set;}
		public object SpatialLocation {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeAddressIDValue {get; set;} = true;

		public bool ShouldSerializeAddressID()
		{
			return ShouldSerializeAddressIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressLine1Value {get; set;} = true;

		public bool ShouldSerializeAddressLine1()
		{
			return ShouldSerializeAddressLine1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeAddressLine2Value {get; set;} = true;

		public bool ShouldSerializeAddressLine2()
		{
			return ShouldSerializeAddressLine2Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeCityValue {get; set;} = true;

		public bool ShouldSerializeCity()
		{
			return ShouldSerializeCityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue {get; set;} = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePostalCodeValue {get; set;} = true;

		public bool ShouldSerializePostalCode()
		{
			return ShouldSerializePostalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpatialLocationValue {get; set;} = true;

		public bool ShouldSerializeSpatialLocation()
		{
			return ShouldSerializeSpatialLocationValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>603f1a62e604b70ec71cbfe563a0ec65</Hash>
</Codenesium>*/