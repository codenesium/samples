using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductListPriceHistoryResponseModel: AbstractApiResponseModel
        {
                public ApiProductListPriceHistoryResponseModel() : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> endDate,
                        decimal listPrice,
                        DateTime modifiedDate,
                        int productID,
                        DateTime startDate)
                {
                        this.EndDate = endDate;
                        this.ListPrice = listPrice;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.StartDate = startDate;
                }

                public Nullable<DateTime> EndDate { get; private set; }

                public decimal ListPrice { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public DateTime StartDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEndDateValue { get; set; } = true;

                public bool ShouldSerializeEndDate()
                {
                        return this.ShouldSerializeEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeListPriceValue { get; set; } = true;

                public bool ShouldSerializeListPrice()
                {
                        return this.ShouldSerializeListPriceValue;
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
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeListPriceValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeStartDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1f91a663ff2209b31397d6a0357d0a9b</Hash>
</Codenesium>*/