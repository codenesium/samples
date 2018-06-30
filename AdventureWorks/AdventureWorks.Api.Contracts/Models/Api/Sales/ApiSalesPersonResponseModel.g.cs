using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        decimal bonus,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        decimal? salesQuota,
                        decimal salesYTD,
                        int? territoryID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Bonus = bonus;
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

                public decimal? SalesQuota { get; private set; }

                public decimal SalesYTD { get; private set; }

                public int? TerritoryID { get; private set; }

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
    <Hash>295a01bd21860e2850ce817b9b4056d1</Hash>
</Codenesium>*/