using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderHeaderSalesReasonRequestModel : AbstractApiRequestModel
        {
                public ApiSalesOrderHeaderSalesReasonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>bb58ab00b0f179d1271f70aafd1bcacd</Hash>
</Codenesium>*/