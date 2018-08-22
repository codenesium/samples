using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("lessonId")]
		public int LessonId { get; private set; }

		[Column("studentId")]
		public int StudentId { get; private set; }

		[ForeignKey("LessonId")]
		public virtual Lesson LessonNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0f098ca1cece5cc078e9db2958fe8bfe</Hash>
</Codenesium>*/