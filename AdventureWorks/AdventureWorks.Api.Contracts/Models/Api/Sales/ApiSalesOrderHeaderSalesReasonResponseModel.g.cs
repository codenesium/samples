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
        }
}

/*<Codenesium>
    <Hash>700438621ce5b85ab1e51c11e79f2be9</Hash>
</Codenesium>*/