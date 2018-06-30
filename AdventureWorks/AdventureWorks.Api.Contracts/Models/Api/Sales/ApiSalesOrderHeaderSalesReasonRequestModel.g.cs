using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>e04c2ade5257b9ba9530d26aa0942e10</Hash>
</Codenesium>*/