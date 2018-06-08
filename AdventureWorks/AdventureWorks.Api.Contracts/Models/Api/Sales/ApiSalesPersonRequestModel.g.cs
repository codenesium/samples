using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesPersonRequestModel: AbstractApiRequestModel
        {
                public ApiSalesPersonRequestModel() : base()
                {
                }

                public void SetProperties(
                        decimal bonus,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        Nullable<decimal> salesQuota,
                        decimal salesYTD,
                        Nullable<int> territoryID)
                {
                        this.Bonus = bonus;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;
                }

                private decimal bonus;

                [Required]
                public decimal Bonus
                {
                        get
                        {
                                return this.bonus;
                        }

                        set
                        {
                                this.bonus = value;
                        }
                }

                private decimal commissionPct;

                [Required]
                public decimal CommissionPct
                {
                        get
                        {
                                return this.commissionPct;
                        }

                        set
                        {
                                this.commissionPct = value;
                        }
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

                private decimal salesLastYear;

                [Required]
                public decimal SalesLastYear
                {
                        get
                        {
                                return this.salesLastYear;
                        }

                        set
                        {
                                this.salesLastYear = value;
                        }
                }

                private Nullable<decimal> salesQuota;

                public Nullable<decimal> SalesQuota
                {
                        get
                        {
                                return this.salesQuota.IsEmptyOrZeroOrNull() ? null : this.salesQuota;
                        }

                        set
                        {
                                this.salesQuota = value;
                        }
                }

                private decimal salesYTD;

                [Required]
                public decimal SalesYTD
                {
                        get
                        {
                                return this.salesYTD;
                        }

                        set
                        {
                                this.salesYTD = value;
                        }
                }

                private Nullable<int> territoryID;

                public Nullable<int> TerritoryID
                {
                        get
                        {
                                return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e478ea8e8f0ccbac02375943db89c0be</Hash>
</Codenesium>*/