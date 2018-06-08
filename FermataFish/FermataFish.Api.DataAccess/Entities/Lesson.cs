using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Lesson", Schema="dbo")]
        public partial class Lesson:AbstractEntity
        {
                public Lesson()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> actualEndDate,
                        Nullable<DateTime> actualStartDate,
                        Nullable<decimal> billAmount,
                        int id,
                        int lessonStatusId,
                        Nullable<DateTime> scheduledEndDate,
                        Nullable<DateTime> scheduledStartDate,
                        string studentNotes,
                        int studioId,
                        string teacherNotes)
                {
                        this.ActualEndDate = actualEndDate;
                        this.ActualStartDate = actualStartDate;
                        this.BillAmount = billAmount;
                        this.Id = id;
                        this.LessonStatusId = lessonStatusId;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                        this.StudentNotes = studentNotes;
                        this.StudioId = studioId;
                        this.TeacherNotes = teacherNotes;
                }

                [Column("actualEndDate", TypeName="datetime")]
                public Nullable<DateTime> ActualEndDate { get; private set; }

                [Column("actualStartDate", TypeName="date")]
                public Nullable<DateTime> ActualStartDate { get; private set; }

                [Column("billAmount", TypeName="money")]
                public Nullable<decimal> BillAmount { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("lessonStatusId", TypeName="int")]
                public int LessonStatusId { get; private set; }

                [Column("scheduledEndDate", TypeName="datetime")]
                public Nullable<DateTime> ScheduledEndDate { get; private set; }

                [Column("scheduledStartDate", TypeName="datetime")]
                public Nullable<DateTime> ScheduledStartDate { get; private set; }

                [Column("studentNotes", TypeName="text(2147483647)")]
                public string StudentNotes { get; private set; }

                [Column("studioId", TypeName="int")]
                public int StudioId { get; private set; }

                [Column("teacherNotes", TypeName="text(2147483647)")]
                public string TeacherNotes { get; private set; }

                [ForeignKey("LessonStatusId")]
                public virtual LessonStatus LessonStatus { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>1b2e4333562dad0d2bdc9dda18ffb017</Hash>
</Codenesium>*/