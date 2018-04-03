using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOVendor
	{
		public POCOVendor()
		{}

		public POCOVendor(int businessEntityID,
		                  string accountNumber,
		                  string name,
		                  int creditRating,
		                  bool preferredVendorStatus,
		                  bool activeFlag,
		                  string purchasingWebServiceURL,
		                  DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AccountNumber = accountNumber;
			this.Name = name;
			this.CreditRating = creditRating;
			this.PreferredVendorStatus = preferredVendorStatus;
			this.ActiveFlag = activeFlag;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int BusinessEntityID {get; set;}
		public string AccountNumber {get; set;}
		public string Name {get; set;}
		public int CreditRating {get; set;}
		public bool PreferredVendorStatus {get; set;}
		public bool ActiveFlag {get; set;}
		public string PurchasingWebServiceURL {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue {get; set;} = true;

		public bool ShouldSerializeAccountNumber()
		{
			return ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCreditRatingValue {get; set;} = true;

		public bool ShouldSerializeCreditRating()
		{
			return ShouldSerializeCreditRatingValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePreferredVendorStatusValue {get; set;} = true;

		public bool ShouldSerializePreferredVendorStatus()
		{
			return ShouldSerializePreferredVendorStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActiveFlagValue {get; set;} = true;

		public bool ShouldSerializeActiveFlag()
		{
			return ShouldSerializeActiveFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePurchasingWebServiceURLValue {get; set;} = true;

		public bool ShouldSerializePurchasingWebServiceURL()
		{
			return ShouldSerializePurchasingWebServiceURLValue;
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
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeCreditRatingValue = false;
			this.ShouldSerializePreferredVendorStatusValue = false;
			this.ShouldSerializeActiveFlagValue = false;
			this.ShouldSerializePurchasingWebServiceURLValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e9e52adef647ea69b83f239a273f1b80</Hash>
</Codenesium>*/