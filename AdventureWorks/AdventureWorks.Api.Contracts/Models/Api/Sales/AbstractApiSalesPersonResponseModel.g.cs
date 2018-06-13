using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesPersonResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal bonus,
                        int businessEntityID,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        Nullable<decimal> salesQuota,
                        decimal salesYTD,
                        Nullable<int> territoryID)
                {
                        this.Bonus = bonus;
                        this.BusinessEntityID = businessEntityID;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;

                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public decimal Bonus { get; private set; }

                public int BusinessEntityID { get; private set; }

                public decimal CommissionPct { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesLastYear { get; private set; }

                public Nullable<decimal> SalesQuota { get; private set; }

                public decimal SalesYTD { get; private set; }

                public Nullable<int> TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeBonusValue { get; set; } = true;

                public bool ShouldSerializeBonus()
                {
                        return this.ShouldSerializeBonusValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCommissionPctValue { get; set; } = true;

                public bool ShouldSerializeCommissionPct()
                {
                        return this.ShouldSerializeCommissionPctValue;
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
                public bool ShouldSerializeSalesLastYearValue { get; set; } = true;

                public bool ShouldSerializeSalesLastYear()
                {
                        return this.ShouldSerializeSalesLastYearValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesQuotaValue { get; set; } = true;

                public bool ShouldSerializeSalesQuota()
                {
                        return this.ShouldSerializeSalesQuotaValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesYTDValue { get; set; } = true;

                public bool ShouldSerializeSalesYTD()
                {
                        return this.ShouldSerializeSalesYTDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTerritoryIDValue { get; set; } = true;

                public bool ShouldSerializeTerritoryID()
                {
                        return this.ShouldSerializeTerritoryIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBonusValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeCommissionPctValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalesLastYearValue = false;
                        this.ShouldSerializeSalesQuotaValue = false;
                        this.ShouldSerializeSalesYTDValue = false;
                        this.ShouldSerializeTerritoryIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1d6d89ba35736afccb0ea391888edee8</Hash>
</Codenesium>*/