using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Lesson", Schema="dbo")]
	public partial class Lesson : AbstractEntity
	{
		public Lesson()
		{
		}

		public virtual void SetProperties(
			int id,
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int lessonStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate,
			string studentNote,
			string teacherNote,
			int studioId)
		{
			this.Id = id;
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.LessonStatusId = lessonStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNote = studentNote;
			this.TeacherNote = teacherNote;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("actualEndDate")]
		public DateTime? ActualEndDate { get; private set; }

		[Column("actualStartDate")]
		public DateTime? ActualStartDate { get; private set; }

		[Column("billAmount")]
		public decimal? BillAmount { get; private set; }

		[Column("lessonStatusId")]
		public int LessonStatusId { get; private set; }

		[Column("scheduledEndDate")]
		public DateTime? ScheduledEndDate { get; private set; }

		[Column("scheduledStartDate")]
		public DateTime? ScheduledStartDate { get; private set; }

		[MaxLength(2147483647)]
		[Column("studentNotes")]
		public string StudentNote { get; private set; }

		[MaxLength(2147483647)]
		[Column("teacherNotes")]
		public string TeacherNote { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6de0983b3e318f7ff8b849ed590fb0c4</Hash>
</Codenesium>*/