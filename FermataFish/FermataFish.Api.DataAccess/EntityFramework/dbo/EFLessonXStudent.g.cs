using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonXStudent", Schema="dbo")]
	public partial class EFLessonXStudent: AbstractEntityFrameworkPOCO
	{
		public EFLessonXStudent()
		{}

		public void SetProperties(
			int id,
			int lessonId,
			int studentId)
		{
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
			this.Id = id.ToInt();
		}

		[Column("lessonId", TypeName="int")]
		public int LessonId { get; set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[ForeignKey("LessonId")]
		public virtual EFLesson Lesson { get; set; }

		[ForeignKey("StudentId")]
		public virtual EFStudent Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>0105bbf70d1c1471c93aced0e9a492c3</Hash>
</Codenesium>*/