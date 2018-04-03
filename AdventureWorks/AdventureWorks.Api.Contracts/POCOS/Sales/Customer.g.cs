using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCustomer
	{
		public POCOCustomer()
		{}

		public POCOCustomer(int customerID,
		                    Nullable<int> personID,
		                    Nullable<int> storeID,
		                    Nullable<int> territoryID,
		                    string accountNumber,
		                    Guid rowguid,
		                    DateTime modifiedDate)
		{
			this.CustomerID = customerID.ToInt();
			this.PersonID = personID.ToNullableInt();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.AccountNumber = accountNumber;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int CustomerID {get; set;}
		public Nullable<int> PersonID {get; set;}
		public Nullable<int> StoreID {get; set;}
		public Nullable<int> TerritoryID {get; set;}
		public string AccountNumber {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue {get; set;} = true;

		public bool ShouldSerializeCustomerID()
		{
			return ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue {get; set;} = true;

		public bool ShouldSerializePersonID()
		{
			return ShouldSerializePersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStoreIDValue {get; set;} = true;

		public bool ShouldSerializeStoreID()
		{
			return ShouldSerializeStoreIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue {get; set;} = true;

		public bool ShouldSerializeTerritoryID()
		{
			return ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue {get; set;} = true;

		public bool ShouldSerializeAccountNumber()
		{
			return ShouldSerializeAccountNumberValue;
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
			this.ShouldSerializeCustomerIDValue = false;
			this.ShouldSerializePersonIDValue = false;
			this.ShouldSerializeStoreIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>aa8181a00a72a1a2a3fc9d2714f9783d</Hash>
</Codenesium>*/