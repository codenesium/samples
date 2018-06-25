using Codenesium.DataConversionExtensions;
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
    <Hash>36aabfc90287ac2bb6d086d6cfb6e693</Hash>
</Codenesium>*/