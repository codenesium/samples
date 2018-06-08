using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ShipMethod", Schema="Purchasing")]
        public partial class ShipMethod: AbstractEntity
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

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("ShipBase", TypeName="money")]
                public decimal ShipBase { get; private set; }

                [Key]
                [Column("ShipMethodID", TypeName="int")]
                public int ShipMethodID { get; private set; }

                [Column("ShipRate", TypeName="money")]
                public decimal ShipRate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>63d7e6b9ee3b55349c11f86892c532c7</Hash>
</Codenesium>*/