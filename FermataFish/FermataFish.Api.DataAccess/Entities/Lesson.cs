using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Lesson", Schema="dbo")]
        public partial class Lesson : AbstractEntity
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

                [Column("actualEndDate")]
                public Nullable<DateTime> ActualEndDate { get; private set; }

                [Column("actualStartDate")]
                public Nullable<DateTime> ActualStartDate { get; private set; }

                [Column("billAmount")]
                public Nullable<decimal> BillAmount { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lessonStatusId")]
                public int LessonStatusId { get; private set; }

                [Column("scheduledEndDate")]
                public Nullable<DateTime> ScheduledEndDate { get; private set; }

                [Column("scheduledStartDate")]
                public Nullable<DateTime> ScheduledStartDate { get; private set; }

                [Column("studentNotes")]
                public string StudentNotes { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [Column("teacherNotes")]
                public string TeacherNotes { get; private set; }

                [ForeignKey("LessonStatusId")]
                public virtual LessonStatus LessonStatus { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>7ea9ef325f4e51759098ac7c12a41732</Hash>
</Codenesium>*/