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
    <Hash>a0df7c7656914fcd0d35c2512562e619</Hash>
</Codenesium>*/