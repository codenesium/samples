using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Lesson", Schema="dbo")]
        public partial class Lesson : AbstractEntity
        {
                public Lesson()
                {
                }

                public virtual void SetProperties(
                        DateTime? actualEndDate,
                        DateTime? actualStartDate,
                        decimal? billAmount,
                        int id,
                        int lessonStatusId,
                        DateTime? scheduledEndDate,
                        DateTime? scheduledStartDate,
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
                public DateTime? ActualEndDate { get; private set; }

                [Column("actualStartDate")]
                public DateTime? ActualStartDate { get; private set; }

                [Column("billAmount")]
                public decimal? BillAmount { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lessonStatusId")]
                public int LessonStatusId { get; private set; }

                [Column("scheduledEndDate")]
                public DateTime? ScheduledEndDate { get; private set; }

                [Column("scheduledStartDate")]
                public DateTime? ScheduledStartDate { get; private set; }

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
    <Hash>f5185bb0b66839f441dfea33b6a8783c</Hash>
</Codenesium>*/