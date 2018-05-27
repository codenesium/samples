using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiAddressResponseModel: AbstractApiResponseModel
	{
		public ApiAddressResponseModel() : base()
		{}

		public void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			int stateProvinceID)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PostalCode = postalCode;
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceID = stateProvinceID.ToInt();
		}

		public int AddressID { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PostalCode { get; set; }
		public Guid Rowguid { get; set; }
		public int StateProvinceID { get; set; }

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
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePostalCodeValue { get; set; } = true;

		public bool ShouldSerializePostalCode()
		{
			return this.ShouldSerializePostalCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAddressIDValue = false;
			this.ShouldSerializeAddressLine1Value = false;
			this.ShouldSerializeAddressLine2Value = false;
			this.ShouldSerializeCityValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePostalCodeValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>87034886a65f9e09a70ded81e0fd373d</Hash>
</Codenesium>*/