using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonXTeacher", Schema="dbo")]
	public partial class LessonXTeacher: AbstractEntityFrameworkDTO
	{
		public LessonXTeacher()
		{}

		public void SetProperties(
			int id,
			int lessonId,
			int studentId)
		{
			this.Id = id.ToInt();
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lessonId", TypeName="int")]
		public int LessonId { get; set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; set; }

		[ForeignKey("LessonId")]
		public virtual Lesson Lesson { get; set; }

		[ForeignKey("StudentId")]
		public virtual Student Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>809839bcb31bf1e8ae654569896f375d</Hash>
</Codenesium>*/