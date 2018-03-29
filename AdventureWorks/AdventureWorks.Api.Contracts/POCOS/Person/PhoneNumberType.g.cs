using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPhoneNumberType
	{
		public POCOPhoneNumberType()
		{}

		public POCOPhoneNumberType(int phoneNumberTypeID,
		                           string name,
		                           DateTime modifiedDate)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int PhoneNumberTypeID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberTypeIDValue {get; set;} = true;

		public bool ShouldSerializePhoneNumberTypeID()
		{
			return ShouldSerializePhoneNumberTypeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializePhoneNumberTypeIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8e7b8889e800994d94eaae7342a62108</Hash>
</Codenesium>*/