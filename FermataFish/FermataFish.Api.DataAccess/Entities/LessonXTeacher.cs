using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonXTeacher", Schema="dbo")]
        public partial class LessonXTeacher: AbstractEntity
        {
                public LessonXTeacher()
                {
                }

                public void SetProperties(
                        int id,
                        int lessonId,
                        int studentId)
                {
                        this.Id = id;
                        this.LessonId = lessonId;
                        this.StudentId = studentId;
                }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("lessonId", TypeName="int")]
                public int LessonId { get; private set; }

                [Column("studentId", TypeName="int")]
                public int StudentId { get; private set; }

                [ForeignKey("LessonId")]
                public virtual Lesson Lesson { get; set; }

                [ForeignKey("StudentId")]
                public virtual Student Student { get; set; }
        }
}

/*<Codenesium>
    <Hash>2bf2871660202a4b8168a5c64f819f0a</Hash>
</Codenesium>*/