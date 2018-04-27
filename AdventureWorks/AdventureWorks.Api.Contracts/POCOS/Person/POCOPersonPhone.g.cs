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
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber.ToString();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.People));
			this.PhoneNumberTypeID = new ReferenceEntity<int>(phoneNumberTypeID,
			                                                  nameof(ApiResponse.PhoneNumberTypes));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PhoneNumber { get; set; }
		public ReferenceEntity<int> PhoneNumberTypeID { get; set; }

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
    <Hash>eeb39cef2ef0e1bbc4da5d9420f55d54</Hash>
</Codenesium>*/