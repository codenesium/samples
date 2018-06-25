using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonXTeacher", Schema="dbo")]
        public partial class LessonXTeacher : AbstractEntity
        {
                public LessonXTeacher()
                {
                }

                public virtual void SetProperties(
                        int id,
                        int lessonId,
                        int studentId)
                {
                        this.Id = id;
                        this.LessonId = lessonId;
                        this.StudentId = studentId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("lessonId")]
                public int LessonId { get; private set; }

                [Column("studentId")]
                public int StudentId { get; private set; }

                [ForeignKey("LessonId")]
                public virtual Lesson Lesson { get; set; }

                [ForeignKey("StudentId")]
                public virtual Student Student { get; set; }
        }
}

/*<Codenesium>
    <Hash>1102537c48ad88b0f396f3312f8572b7</Hash>
</Codenesium>*/