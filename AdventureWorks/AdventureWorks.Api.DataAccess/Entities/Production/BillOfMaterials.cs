using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BillOfMaterials", Schema="Production")]
        public partial class BillOfMaterials: AbstractEntity
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
                [Column("BillOfMaterialsID", TypeName="int")]
                public int BillOfMaterialsID { get; private set; }

                [Column("BOMLevel", TypeName="smallint")]
                public short BOMLevel { get; private set; }

                [Column("ComponentID", TypeName="int")]
                public int ComponentID { get; private set; }

                [Column("EndDate", TypeName="datetime")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PerAssemblyQty", TypeName="decimal")]
                public decimal PerAssemblyQty { get; private set; }

                [Column("ProductAssemblyID", TypeName="int")]
                public Nullable<int> ProductAssemblyID { get; private set; }

                [Column("StartDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }

                [Column("UnitMeasureCode", TypeName="nchar(3)")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2a31ecfc1d7717e198b8408cfbe9bd97</Hash>
</Codenesium>*/