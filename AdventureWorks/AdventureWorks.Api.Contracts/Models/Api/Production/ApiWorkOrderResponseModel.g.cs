using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiWorkOrderResponseModel: AbstractApiResponseModel
        {
                public ApiWorkOrderResponseModel() : base()
                {
                }

                public void SetProperties(
                        DateTime dueDate,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int orderQty,
                        int productID,
                        short scrappedQty,
                        Nullable<short> scrapReasonID,
                        DateTime startDate,
                        int stockedQty,
                        int workOrderID)
                {
                        this.DueDate = dueDate;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.ScrappedQty = scrappedQty;
                        this.ScrapReasonID = scrapReasonID;
                        this.StartDate = startDate;
                        this.StockedQty = stockedQty;
                        this.WorkOrderID = workOrderID;
                }

                public DateTime DueDate { get; private set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int OrderQty { get; private set; }

                public int ProductID { get; private set; }

                public short ScrappedQty { get; private set; }

                public Nullable<short> ScrapReasonID { get; private set; }

                public DateTime StartDate { get; private set; }

                public int StockedQty { get; private set; }

                public int WorkOrderID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDueDateValue { get; set; } = true;

                public bool ShouldSerializeDueDate()
                {
                        return this.ShouldSerializeDueDateValue;
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
                public bool ShouldSerializeOrderQtyValue { get; set; } = true;

                public bool ShouldSerializeOrderQty()
                {
                        return this.ShouldSerializeOrderQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScrappedQtyValue { get; set; } = true;

                public bool ShouldSerializeScrappedQty()
                {
                        return this.ShouldSerializeScrappedQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScrapReasonIDValue { get; set; } = true;

                public bool ShouldSerializeScrapReasonID()
                {
                        return this.ShouldSerializeScrapReasonIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStockedQtyValue { get; set; } = true;

                public bool ShouldSerializeStockedQty()
                {
                        return this.ShouldSerializeStockedQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkOrderIDValue { get; set; } = true;

                public bool ShouldSerializeWorkOrderID()
                {
                        return this.ShouldSerializeWorkOrderIDValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeDueDateValue = false;
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeOrderQtyValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeScrappedQtyValue = false;
                        this.ShouldSerializeScrapReasonIDValue = false;
                        this.ShouldSerializeStartDateValue = false;
                        this.ShouldSerializeStockedQtyValue = false;
                        this.ShouldSerializeWorkOrderIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>14eec5bf6309d7a596476e4e7bd348b1</Hash>
</Codenesium>*/