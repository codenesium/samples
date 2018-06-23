using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiSalesPersonQuotaHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        DateTime quotaDate,
                        Guid rowguid,
                        decimal salesQuota)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.QuotaDate = quotaDate;
                        this.Rowguid = rowguid;
                        this.SalesQuota = salesQuota;

                        this.BusinessEntityIDEntity = nameof(ApiResponse.SalesPersons);
                }

                public int BusinessEntityID { get; private set; }

                public string BusinessEntityIDEntity { get; set; }

                public DateTime ModifiedDate { get; private set; }

                public DateTime QuotaDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesQuota { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeQuotaDateValue { get; set; } = true;

                public bool ShouldSerializeQuotaDate()
                {
                        return this.ShouldSerializeQuotaDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesQuotaValue { get; set; } = true;

                public bool ShouldSerializeSalesQuota()
                {
                        return this.ShouldSerializeSalesQuotaValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeQuotaDateValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalesQuotaValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>9fa8482a835ed038b63cb688f14dff95</Hash>
</Codenesium>*/