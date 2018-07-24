using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Location", Schema="Production")]
        public partial class Location : AbstractEntity
        {
                public Location()
                {
                }

                public virtual void SetProperties(
                        double availability,
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
                public double Availability { get; private set; }

                [Column("CostRate")]
                public decimal CostRate { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("LocationID")]
                public short LocationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f70475ac9f26092c4e8fe5873901602c</Hash>
</Codenesium>*/