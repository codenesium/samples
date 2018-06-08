using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonXStudent", Schema="dbo")]
        public partial class LessonXStudent: AbstractEntity
        {
                public LessonXStudent()
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
    <Hash>599224edd948e78ecc21b5802e5c12eb</Hash>
</Codenesium>*/