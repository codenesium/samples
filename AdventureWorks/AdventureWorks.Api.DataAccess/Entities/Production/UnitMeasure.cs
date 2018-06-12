using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("UnitMeasure", Schema="Production")]
        public partial class UnitMeasure: AbstractEntity
        {
                public UnitMeasure()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string unitMeasureCode)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Key]
                [Column("UnitMeasureCode", TypeName="nchar(3)")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>033bf7d57784a5b913e5c90131ceda31</Hash>
</Codenesium>*/