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
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public string PhoneNumber {get; set;}
		public int PhoneNumberTypeID {get; set;}
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
    <Hash>174202b5cd69407f53c329bd22f03fe8</Hash>
</Codenesium>*/