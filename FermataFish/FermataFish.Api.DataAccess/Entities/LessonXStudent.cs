using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonXStudent", Schema="dbo")]
        public partial class LessonXStudent : AbstractEntity
        {
                public LessonXStudent()
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
    <Hash>6a707984f84dc21dc90ea5222c46405e</Hash>
</Codenesium>*/