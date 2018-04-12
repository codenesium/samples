using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("LessonXStudent", Schema="dbo")]
	public partial class EFLessonXStudent
	{
		public EFLessonXStudent()
		{}

		public void SetProperties(
			int lessonId,
			int studentId,
			int id)
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
    <Hash>ea69043903917d6b46245356ede9b733</Hash>
</Codenesium>*/