using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Shift", Schema="HumanResources")]
        public partial class Shift:AbstractEntity
        {
                public Shift()
                {
                }

                public void SetProperties(
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

                [Column("EndTime", TypeName="time")]
                public TimeSpan EndTime { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Key]
                [Column("ShiftID", TypeName="tinyint")]
                public int ShiftID { get; private set; }

                [Column("StartTime", TypeName="time")]
                public TimeSpan StartTime { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d9d7d92001377548c8884cbec7ecadca</Hash>
</Codenesium>*/