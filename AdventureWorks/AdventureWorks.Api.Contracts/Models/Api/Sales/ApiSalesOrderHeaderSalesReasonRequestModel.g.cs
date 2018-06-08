using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderSalesReasonRequestModel: AbstractApiRequestModel
        {
                public ApiSalesOrderHeaderSalesReasonRequestModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.SalesReasonID = salesReasonID;
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private int salesReasonID;

                [Required]
                public int SalesReasonID
                {
                        get
                        {
                                return this.salesReasonID;
                        }

                        set
                        {
                                this.salesReasonID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5f6a0db371032546215d08b1e27ceb66</Hash>
</Codenesium>*/