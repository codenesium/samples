using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ShipMethod", Schema="Purchasing")]
        public partial class ShipMethod : AbstractEntity
        {
                public ShipMethod()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        decimal shipBase,
                        int shipMethodID,
                        decimal shipRate)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.ShipBase = shipBase;
                        this.ShipMethodID = shipMethodID;
                        this.ShipRate = shipRate;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("ShipBase")]
                public decimal ShipBase { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("ShipMethodID")]
                public int ShipMethodID { get; private set; }

                [Column("ShipRate")]
                public decimal ShipRate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b3a2ccffe635f0d9191eb68bc3450153</Hash>
</Codenesium>*/