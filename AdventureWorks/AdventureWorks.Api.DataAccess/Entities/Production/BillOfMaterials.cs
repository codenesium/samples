using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BillOfMaterials", Schema="Production")]
        public partial class BillOfMaterials : AbstractEntity
        {
                public BillOfMaterials()
                {
                }

                public void SetProperties(
                        int billOfMaterialsID,
                        short bOMLevel,
                        int componentID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        decimal perAssemblyQty,
                        Nullable<int> productAssemblyID,
                        DateTime startDate,
                        string unitMeasureCode)
                {
                        this.BillOfMaterialsID = billOfMaterialsID;
                        this.BOMLevel = bOMLevel;
                        this.ComponentID = componentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.PerAssemblyQty = perAssemblyQty;
                        this.ProductAssemblyID = productAssemblyID;
                        this.StartDate = startDate;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                [Key]
                [Column("BillOfMaterialsID")]
                public int BillOfMaterialsID { get; private set; }

                [Column("BOMLevel")]
                public short BOMLevel { get; private set; }

                [Column("ComponentID")]
                public int ComponentID { get; private set; }

                [Column("EndDate")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PerAssemblyQty")]
                public decimal PerAssemblyQty { get; private set; }

                [Column("ProductAssemblyID")]
                public Nullable<int> ProductAssemblyID { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }

                [Column("UnitMeasureCode")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>afc6b202c9c66fe0290e717cbec8557f</Hash>
</Codenesium>*/