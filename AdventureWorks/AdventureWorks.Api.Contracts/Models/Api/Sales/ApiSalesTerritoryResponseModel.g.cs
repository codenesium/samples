using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTerritoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int territoryID,
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
                        this.TerritoryID = territoryID;
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

                public decimal CostLastYear { get; private set; }

                public decimal CostYTD { get; private set; }

                public string CountryRegionCode { get; private set; }

                public string @Group { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal SalesLastYear { get; private set; }

                public decimal SalesYTD { get; private set; }

                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>88df5511d82c2e7d7e3a8e7c8a1b96cf</Hash>
</Codenesium>*/