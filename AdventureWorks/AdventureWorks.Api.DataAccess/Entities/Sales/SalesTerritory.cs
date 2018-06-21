using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesTerritory", Schema="Sales")]
        public partial class SalesTerritory : AbstractEntity
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

                [Column("CostLastYear")]
                public decimal CostLastYear { get; private set; }

                [Column("CostYTD")]
                public decimal CostYTD { get; private set; }

                [Column("CountryRegionCode")]
                public string CountryRegionCode { get; private set; }

                [Column("Group")]
                public string @Group { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesLastYear")]
                public decimal SalesLastYear { get; private set; }

                [Column("SalesYTD")]
                public decimal SalesYTD { get; private set; }

                [Key]
                [Column("TerritoryID")]
                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9c8161ecca37723792f2bf076b42f23d</Hash>
</Codenesium>*/