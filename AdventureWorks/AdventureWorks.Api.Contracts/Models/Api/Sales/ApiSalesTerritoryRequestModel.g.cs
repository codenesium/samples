using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTerritoryRequestModel : AbstractApiRequestModel
        {
                public ApiSalesTerritoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        decimal costLastYear,
                        decimal costYTD,
                        string countryRegionCode,
                        string @group,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        decimal salesLastYear,
                        decimal salesYTD)
                {
                        this.CostLastYear = costLastYear;
                        this.CostYTD = costYTD;
                        this.CountryRegionCode = countryRegionCode;
                        this.@Group = @group;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesYTD = salesYTD;
                }

                private decimal costLastYear;

                [Required]
                public decimal CostLastYear
                {
                        get
                        {
                                return this.costLastYear;
                        }

                        set
                        {
                                this.costLastYear = value;
                        }
                }

                private decimal costYTD;

                [Required]
                public decimal CostYTD
                {
                        get
                        {
                                return this.costYTD;
                        }

                        set
                        {
                                this.costYTD = value;
                        }
                }

                private string countryRegionCode;

                [Required]
                public string CountryRegionCode
                {
                        get
                        {
                                return this.countryRegionCode;
                        }

                        set
                        {
                                this.countryRegionCode = value;
                        }
                }

                private string @group;

                [Required]
                public string @Group
                {
                        get
                        {
                                return this.@group;
                        }

                        set
                        {
                                this.@group = value;
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
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
        }
}

/*<Codenesium>
    <Hash>254ac25c739cdb2ed4ac66b1b4b0ed6b</Hash>
</Codenesium>*/