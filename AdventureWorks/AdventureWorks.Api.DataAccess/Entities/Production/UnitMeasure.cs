using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("UnitMeasure", Schema="Production")]
        public partial class UnitMeasure : AbstractEntity
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

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [Column("UnitMeasureCode")]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b1fbf060d512c84730070f852a19515c</Hash>
</Codenesium>*/