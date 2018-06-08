using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesTaxRate", Schema="Sales")]
        public partial class SalesTaxRate: AbstractEntity
        {
                public SalesTaxRate()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int salesTaxRateID,
                        int stateProvinceID,
                        decimal taxRate,
                        int taxType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesTaxRateID = salesTaxRateID;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
                }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SalesTaxRateID", TypeName="int")]
                public int SalesTaxRateID { get; private set; }

                [Column("StateProvinceID", TypeName="int")]
                public int StateProvinceID { get; private set; }

                [Column("TaxRate", TypeName="smallmoney")]
                public decimal TaxRate { get; private set; }

                [Column("TaxType", TypeName="tinyint")]
                public int TaxType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>824c8b6a2386f3c4332c5c2f893506ad</Hash>
</Codenesium>*/