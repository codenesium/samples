using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCostHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productID,
                        DateTime? endDate,
                        DateTime modifiedDate,
                        decimal standardCost,
                        DateTime startDate)
                {
                        this.ProductID = productID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.StandardCost = standardCost;
                        this.StartDate = startDate;
                }

                public DateTime? EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public decimal StandardCost { get; private set; }

                public DateTime StartDate { get; private set; }

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
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStandardCostValue { get; set; } = true;

                public bool ShouldSerializeStandardCost()
                {
                        return this.ShouldSerializeStandardCostValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeStandardCostValue = false;
                        this.ShouldSerializeStartDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>6bc44b41fee3df48938c85710fb8631c</Hash>
</Codenesium>*/