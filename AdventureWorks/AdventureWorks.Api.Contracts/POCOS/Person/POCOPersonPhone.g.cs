using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPersonPhone
	{
		public POCOPersonPhone()
		{}

		public POCOPersonPhone(int businessEntityID,
		                       string phoneNumber,
		                       int phoneNumberTypeID,
		                       DateTime modifiedDate)
		{
			this.PhoneNumber = phoneNumber;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                            "Person");
			PhoneNumberTypeID = new ReferenceEntity<int>(phoneNumberTypeID,
			                                             "PhoneNumberType");
		}

		public ReferenceEntity<int>BusinessEntityID {get; set;}
		public string PhoneNumber {get; set;}
		public ReferenceEntity<int>PhoneNumberTypeID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberValue {get; set;} = true;

		public bool ShouldSerializePhoneNumber()
		{
			return ShouldSerializePhoneNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberTypeIDValue {get; set;} = true;

		public bool ShouldSerializePhoneNumberTypeID()
		{
			return ShouldSerializePhoneNumberTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializePhoneNumberValue = false;
			this.ShouldSerializePhoneNumberTypeIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b074e7fe04268b3230e8865729718ab9</Hash>
</Codenesium>*/