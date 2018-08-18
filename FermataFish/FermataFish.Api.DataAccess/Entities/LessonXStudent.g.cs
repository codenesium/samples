using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
		public virtual Lesson LessonNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7962b50337b0c3117d7129702ebc1bc0</Hash>
</Codenesium>*/