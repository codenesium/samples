using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Lesson", Schema="dbo")]
	public partial class Lesson:AbstractEntityFrameworkPOCO
	{
		public Lesson()
		{}

		public void SetProperties(
			int id,
			Nullable<DateTime> actualEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<decimal> billAmount,
			int lessonStatusId,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> scheduledStartDate,
			string studentNotes,
			int studioId,
			string teacherNotes)
		{
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.BillAmount = billAmount.ToNullableDecimal();
			this.Id = id.ToInt();
			this.LessonStatusId = lessonStatusId.ToInt();
			this.ScheduledEndDate = scheduledEndDate.ToNullableDateTime();
			this.ScheduledStartDate = scheduledStartDate.ToNullableDateTime();
			this.StudentNotes = studentNotes.ToString();
			this.StudioId = studioId.ToInt();
			this.TeacherNotes = teacherNotes.ToString();
		}

		[Column("actualEndDate", TypeName="datetime")]
		public Nullable<DateTime> ActualEndDate { get; set; }

		[Column("actualStartDate", TypeName="date")]
		public Nullable<DateTime> ActualStartDate { get; set; }

		[Column("billAmount", TypeName="money")]
		public Nullable<decimal> BillAmount { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lessonStatusId", TypeName="int")]
		public int LessonStatusId { get; set; }

		[Column("scheduledEndDate", TypeName="datetime")]
		public Nullable<DateTime> ScheduledEndDate { get; set; }

		[Column("scheduledStartDate", TypeName="datetime")]
		public Nullable<DateTime> ScheduledStartDate { get; set; }

		[Column("studentNotes", TypeName="text(2147483647)")]
		public string StudentNotes { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[Column("teacherNotes", TypeName="text(2147483647)")]
		public string TeacherNotes { get; set; }

		[ForeignKey("LessonStatusId")]
		public virtual LessonStatus LessonStatus { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>cd0e8681f966ac6ee0a5b18b65b9e810</Hash>
</Codenesium>*/