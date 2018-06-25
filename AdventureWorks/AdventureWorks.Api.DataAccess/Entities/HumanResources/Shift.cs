using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Shift", Schema="HumanResources")]
        public partial class Shift : AbstractEntity
        {
                public Shift()
                {
                }

                public virtual void SetProperties(
                        TimeSpan endTime,
                        DateTime modifiedDate,
                        string name,
                        int shiftID,
                        TimeSpan startTime)
                {
                        this.EndTime = endTime;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ShiftID = shiftID;
                        this.StartTime = startTime;
                }

                [Column("EndTime")]
                public TimeSpan EndTime { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [Column("ShiftID")]
                public int ShiftID { get; private set; }

                [Column("StartTime")]
                public TimeSpan StartTime { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e52a55963069db1a9dbdf5c1a152baf2</Hash>
</Codenesium>*/