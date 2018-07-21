using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("UnitMeasure", Schema="Production")]
        public partial class UnitMeasure : AbstractEntity
        {
                public UnitMeasure()
                {
                }

                public virtual void SetProperties(
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
    <Hash>de4052182357d640f8dafdf354ff2d4c</Hash>
</Codenesium>*/