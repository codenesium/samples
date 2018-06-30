using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderSalesReasonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesOrderID,
                        DateTime modifiedDate,
                        int salesReasonID)
                {
                        this.SalesOrderID = salesOrderID;
                        this.ModifiedDate = modifiedDate;
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
    <Hash>54392b829c0b15411013ba9ca7383b91</Hash>
</Codenesium>*/