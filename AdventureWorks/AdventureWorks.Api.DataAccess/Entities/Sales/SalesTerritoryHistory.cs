using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesTerritoryHistory", Schema="Sales")]
        public partial class SalesTerritoryHistory: AbstractEntity
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
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("EndDate", TypeName="datetime")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("StartDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }

                [Column("TerritoryID", TypeName="int")]
                public int TerritoryID { get; private set; }

                [ForeignKey("BusinessEntityID")]
                public virtual SalesPerson SalesPerson { get; set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>df8f38b6ae88c7828659abe2ba8cbf69</Hash>
</Codenesium>*/