using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderHeaderSalesReasonResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        int salesOrderID,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.SalesOrderID = salesOrderID;
                        this.SalesReasonID = salesReasonID;

                        this.SalesOrderIDEntity = nameof(ApiResponse.SalesOrderHeaders);
                        this.SalesReasonIDEntity = nameof(ApiResponse.SalesReasons);
                }

                public DateTime ModifiedDate { get; private set; }

                public int SalesOrderID { get; private set; }

                public string SalesOrderIDEntity { get; set; }

                public int SalesReasonID { get; private set; }

                public string SalesReasonIDEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

                public bool ShouldSerializeSalesOrderID()
                {
                        return this.ShouldSerializeSalesOrderIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesReasonIDValue { get; set; } = true;

                public bool ShouldSerializeSalesReasonID()
                {
                        return this.ShouldSerializeSalesReasonIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeSalesOrderIDValue = false;
                        this.ShouldSerializeSalesReasonIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>79d0f920b6720ed4b47d3a1803c021b4</Hash>
</Codenesium>*/