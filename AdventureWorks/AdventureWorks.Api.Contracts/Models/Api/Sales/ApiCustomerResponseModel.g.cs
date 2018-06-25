using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCustomerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string accountNumber,
                        int customerID,
                        DateTime modifiedDate,
                        int? personID,
                        Guid rowguid,
                        int? storeID,
                        int? territoryID)
                {
                        this.AccountNumber = accountNumber;
                        this.CustomerID = customerID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                        this.StoreID = storeID;
                        this.TerritoryID = territoryID;

                        this.StoreIDEntity = nameof(ApiResponse.Stores);
                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public string AccountNumber { get; private set; }

                public int CustomerID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int? PersonID { get; private set; }

                public Guid Rowguid { get; private set; }

                public int? StoreID { get; private set; }

                public string StoreIDEntity { get; set; }

                public int? TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }

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

                public virtual void DisableAllFields()
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
    <Hash>8a8f7f444963cf5f9837675fa34e3b7b</Hash>
</Codenesium>*/