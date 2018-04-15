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
			string phoneNumber,
			int phoneNumberTypeID,
			DateTime modifiedDate)
		{
			this.PhoneNumber = phoneNumber.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.People));
			this.PhoneNumberTypeID = new ReferenceEntity<int>(phoneNumberTypeID,
			                                                  nameof(ApiResponse.PhoneNumberTypes));
		}

		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public string PhoneNumber { get; set; }
		public ReferenceEntity<int> PhoneNumberTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
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

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
    <Hash>1fe7ba9057be40106028721db91c3b90</Hash>
</Codenesium>*/