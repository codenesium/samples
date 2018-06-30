using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonQuotaHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiSalesPersonQuotaHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        DateTime quotaDate,
                        Guid rowguid,
                        decimal salesQuota)
                {
                        this.ModifiedDate = modifiedDate;
                        this.QuotaDate = quotaDate;
                        this.Rowguid = rowguid;
                        this.SalesQuota = salesQuota;
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

                private DateTime quotaDate;

                [Required]
                public DateTime QuotaDate
                {
                        get
                        {
                                return this.quotaDate;
                        }

                        set
                        {
                                this.quotaDate = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private decimal salesQuota;

                [Required]
                public decimal SalesQuota
                {
                        get
                        {
                                return this.salesQuota;
                        }

                        set
                        {
                                this.salesQuota = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f0c631648e30db349443a3a1a3a13f07</Hash>
</Codenesium>*/