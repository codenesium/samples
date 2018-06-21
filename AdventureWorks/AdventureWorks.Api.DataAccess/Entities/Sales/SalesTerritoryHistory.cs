using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesTerritoryHistory", Schema="Sales")]
        public partial class SalesTerritoryHistory : AbstractEntity
        {
                public SalesTerritoryHistory()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        Guid rowguid,
                        DateTime startDate,
                        int territoryID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.StartDate = startDate;
                        this.TerritoryID = territoryID;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("EndDate")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }

                [Column("TerritoryID")]
                public int TerritoryID { get; private set; }

                [ForeignKey("BusinessEntityID")]
                public virtual SalesPerson SalesPerson { get; set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>c4112f6d80dfb516f2ef023dd7c3078b</Hash>
</Codenesium>*/