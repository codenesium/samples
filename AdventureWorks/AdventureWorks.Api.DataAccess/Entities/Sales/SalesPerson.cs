using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesPerson", Schema="Sales")]
        public partial class SalesPerson : AbstractEntity
        {
                public SalesPerson()
                {
                }

                public void SetProperties(
                        decimal bonus,
                        int businessEntityID,
                        decimal commissionPct,
                        DateTime modifiedDate,
                        Guid rowguid,
                        decimal salesLastYear,
                        Nullable<decimal> salesQuota,
                        decimal salesYTD,
                        Nullable<int> territoryID)
                {
                        this.Bonus = bonus;
                        this.BusinessEntityID = businessEntityID;
                        this.CommissionPct = commissionPct;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SalesLastYear = salesLastYear;
                        this.SalesQuota = salesQuota;
                        this.SalesYTD = salesYTD;
                        this.TerritoryID = territoryID;
                }

                [Column("Bonus")]
                public decimal Bonus { get; private set; }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("CommissionPct")]
                public decimal CommissionPct { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesLastYear")]
                public decimal SalesLastYear { get; private set; }

                [Column("SalesQuota")]
                public Nullable<decimal> SalesQuota { get; private set; }

                [Column("SalesYTD")]
                public decimal SalesYTD { get; private set; }

                [Column("TerritoryID")]
                public Nullable<int> TerritoryID { get; private set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>0d61146c251914675e3b832ac0af0d36</Hash>
</Codenesium>*/