using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Location", Schema="Production")]
        public partial class Location : AbstractEntity
        {
                public Location()
                {
                }

                public virtual void SetProperties(
                        decimal availability,
                        decimal costRate,
                        short locationID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.Availability = availability;
                        this.CostRate = costRate;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Column("Availability")]
                public decimal Availability { get; private set; }

                [Column("CostRate")]
                public decimal CostRate { get; private set; }

                [Key]
                [Column("LocationID")]
                public short LocationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>747e13898b14d929af02161327eb9130</Hash>
</Codenesium>*/