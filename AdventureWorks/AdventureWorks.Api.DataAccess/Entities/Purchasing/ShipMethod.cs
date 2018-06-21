using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ShipMethod", Schema="Purchasing")]
        public partial class ShipMethod : AbstractEntity
        {
                public ShipMethod()
                {
                }

                public void SetProperties(
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

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("ShipBase")]
                public decimal ShipBase { get; private set; }

                [Key]
                [Column("ShipMethodID")]
                public int ShipMethodID { get; private set; }

                [Column("ShipRate")]
                public decimal ShipRate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>99990f7b2ca01bba8dbdda8af0171dd9</Hash>
</Codenesium>*/