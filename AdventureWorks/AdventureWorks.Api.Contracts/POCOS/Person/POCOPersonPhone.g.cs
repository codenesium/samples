using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPersonPhone
	{
		public POCOPersonPhone()
		{}

		public POCOPersonPhone(
			int businessEntityID,
			DateTime modifiedDate,
			string phoneNumber,
			int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber.ToString();
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PhoneNumber { get; set; }
		public int PhoneNumberTypeID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberValue { get; set; } = true;

		public bool ShouldSerializePhoneNumber()
		{
			return this.ShouldSerializePhoneNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneNumberTypeIDValue { get; set; } = true;

		public bool ShouldSerializePhoneNumberTypeID()
		{
			return this.ShouldSerializePhoneNumberTypeIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePhoneNumberValue = false;
			this.ShouldSerializePhoneNumberTypeIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c8e2aec76b65da77e60d2f1c03c4e85f</Hash>
</Codenesium>*/