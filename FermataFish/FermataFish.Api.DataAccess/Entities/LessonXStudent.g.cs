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
			int studentId,
			int studioId)
		{
			this.Id = id;
			this.LessonId = lessonId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("lessonId")]
		public int LessonId { get; private set; }

		[Column("studentId")]
		public int StudentId { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("LessonId")]
		public virtual Lesson LessonNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9c3b8d42fdceb452ad99fc8422c0f8b4</Hash>
</Codenesium>*/