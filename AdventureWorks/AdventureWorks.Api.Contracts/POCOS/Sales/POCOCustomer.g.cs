using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCustomer
	{
		public POCOCustomer()
		{}

		public POCOCustomer(
			int customerID,
			Nullable<int> personID,
			Nullable<int> storeID,
			Nullable<int> territoryID,
			string accountNumber,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.CustomerID = customerID.ToInt();
			this.AccountNumber = accountNumber;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.PersonID = new ReferenceEntity<Nullable<int>>(personID,
			                                                   "Person");
			this.StoreID = new ReferenceEntity<Nullable<int>>(storeID,
			                                                  "Store");
			this.TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                      "SalesTerritory");
		}

		public int CustomerID { get; set; }
		public ReferenceEntity<Nullable<int>> PersonID { get; set; }
		public ReferenceEntity<Nullable<int>> StoreID { get; set; }
		public ReferenceEntity<Nullable<int>> TerritoryID { get; set; }
		public string AccountNumber { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue { get; set; } = true;

		public bool ShouldSerializeCustomerID()
		{
			return this.ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue { get; set; } = true;

		public bool ShouldSerializePersonID()
		{
			return this.ShouldSerializePersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStoreIDValue { get; set; } = true;

		public bool ShouldSerializeStoreID()
		{
			return this.ShouldSerializeStoreIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

		public bool ShouldSerializeTerritoryID()
		{
			return this.ShouldSerializeTerritoryIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue { get; set; } = true;

		public bool ShouldSerializeAccountNumber()
		{
			return this.ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
    <Hash>afeffe08e9bfe97f197adb9487dba59e</Hash>
</Codenesium>*/