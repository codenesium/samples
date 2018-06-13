using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesTerritoryHistoryResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        Guid rowguid,
                        DateTime startDate,
                        int territoryID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.StartDate = startDate;
                        this.TerritoryID = territoryID;

                        this.BusinessEntityIDEntity = nameof(ApiResponse.SalesPersons);
                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public int BusinessEntityID { get; private set; }

                public string BusinessEntityIDEntity { get; set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public DateTime StartDate { get; private set; }

                public int TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEndDateValue { get; set; } = true;

                public bool ShouldSerializeEndDate()
                {
                        return this.ShouldSerializeEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

                public bool ShouldSerializeTerritoryID()
                {
                        return this.ShouldSerializeTerritoryIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeStartDateValue = false;
                        this.ShouldSerializeTerritoryIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8df6b3e82e68100eb2c355efb2e5782a</Hash>
</Codenesium>*/