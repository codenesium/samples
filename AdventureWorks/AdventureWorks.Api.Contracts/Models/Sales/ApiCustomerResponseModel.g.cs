using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCustomerResponseModel: AbstractApiResponseModel
	{
		public ApiCustomerResponseModel() : base()
		{}

		public void SetProperties(
			string accountNumber,
			int customerID,
			DateTime modifiedDate,
			Nullable<int> personID,
			Guid rowguid,
			Nullable<int> storeID,
			Nullable<int> territoryID)
		{
			this.AccountNumber = accountNumber;
			this.CustomerID = customerID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToNullableInt();
			this.Rowguid = rowguid.ToGuid();

			this.StoreID = new ReferenceEntity<Nullable<int>>(storeID,
			                                                  nameof(ApiResponse.Stores));
			this.TerritoryID = new ReferenceEntity<Nullable<int>>(territoryID,
			                                                      nameof(ApiResponse.SalesTerritories));
		}

		public string AccountNumber { get; set; }
		public int CustomerID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<int> PersonID { get; set; }
		public Guid Rowguid { get; set; }
		public ReferenceEntity<Nullable<int>> StoreID { get; set; }
		public ReferenceEntity<Nullable<int>> TerritoryID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAccountNumberValue { get; set; } = true;

		public bool ShouldSerializeAccountNumber()
		{
			return this.ShouldSerializeAccountNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCustomerIDValue { get; set; } = true;

		public bool ShouldSerializeCustomerID()
		{
			return this.ShouldSerializeCustomerIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePersonIDValue { get; set; } = true;

		public bool ShouldSerializePersonID()
		{
			return this.ShouldSerializePersonIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
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

		public void DisableAllFields()
		{
			this.ShouldSerializeAccountNumberValue = false;
			this.ShouldSerializeCustomerIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePersonIDValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeStoreIDValue = false;
			this.ShouldSerializeTerritoryIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>35c8a5c50d38c7515ad133ed9d2d6c01</Hash>
</Codenesium>*/