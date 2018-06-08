using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesTerritory", Schema="Sales")]
        public partial class SalesTerritory: AbstractEntity
        {
                public SalesTerritory()
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
                        decimal salesYTD,
                        int territoryID)
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
                        this.TerritoryID = territoryID;
                }

                [Column("CostLastYear", TypeName="money")]
                public decimal CostLastYear { get; private set; }

                [Column("CostYTD", TypeName="money")]
                public decimal CostYTD { get; private set; }

                [Column("CountryRegionCode", TypeName="nvarchar(3)")]
                public string CountryRegionCode { get; private set; }

                [Column("Group", TypeName="nvarchar(50)")]
                public string @Group { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("SalesLastYear", TypeName="money")]
                public decimal SalesLastYear { get; private set; }

                [Column("SalesYTD", TypeName="money")]
                public decimal SalesYTD { get; private set; }

                [Key]
                [Column("TerritoryID", TypeName="int")]
                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d4aa9da76a434eb167f05106216e314b</Hash>
</Codenesium>*/