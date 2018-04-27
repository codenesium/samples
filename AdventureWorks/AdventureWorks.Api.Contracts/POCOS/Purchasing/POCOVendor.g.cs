using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOVendor
	{
		public POCOVendor()
		{}

		public POCOVendor(
			string accountNumber,
			bool activeFlag,
			int businessEntityID,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatus,
			string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber.ToString();
			this.ActiveFlag = activeFlag.ToBoolean();
			this.CreditRating = creditRating.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL.ToString();

			this.BusinessEntityID = new ReferenceEntity<int>(businessEntityID,
			                                                 nameof(ApiResponse.BusinessEntities));
		}

		public string AccountNumber { get; set; }
		public bool ActiveFlag { get; set; }
		public ReferenceEntity<int> BusinessEntityID { get; set; }
		public int CreditRating { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public bool PreferredVendorStatus { get; set; }
		public string PurchasingWebServiceURL { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue { get; set; } = true;

		public bool ShouldSerializeAccountNumber()
		{
			return this.ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActiveFlagValue { get; set; } = true;

		public bool ShouldSerializeActiveFlag()
		{
			return this.ShouldSerializeActiveFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditRatingValue { get; set; } = true;

		public bool ShouldSerializeCreditRating()
		{
			return this.ShouldSerializeCreditRatingValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreferredVendorStatusValue { get; set; } = true;

		public bool ShouldSerializePreferredVendorStatus()
		{
			return this.ShouldSerializePreferredVendorStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchasingWebServiceURLValue { get; set; } = true;

		public bool ShouldSerializePurchasingWebServiceURL()
		{
			return this.ShouldSerializePurchasingWebServiceURLValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeActiveFlagValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeCreditRatingValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializePreferredVendorStatusValue = false;
			this.ShouldSerializePurchasingWebServiceURLValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8b770f81467353a211ae9b1d8a3148a7</Hash>
</Codenesium>*/