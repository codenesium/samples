using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Lesson", Schema="dbo")]
	public partial class EFLesson: AbstractEntityFrameworkPOCO
	{
		public EFLesson()
		{}

		public void SetProperties(
			int id,
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId)
		{
			this.Id = id.ToInt();
			this.ScheduledStartDate = scheduledStartDate.ToNullableDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToNullableDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.LessonStatusId = lessonStatusId.ToInt();
			this.TeacherNotes = teacherNotes.ToString();
			this.StudentNotes = studentNotes.ToString();
			this.BillAmount = billAmount.ToNullableDecimal();
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("scheduledStartDate", TypeName="datetime")]
		public Nullable<DateTime> ScheduledStartDate { get; set; }

		[Column("scheduledEndDate", TypeName="datetime")]
		public Nullable<DateTime> ScheduledEndDate { get; set; }

		[Column("actualStartDate", TypeName="date")]
		public Nullable<DateTime> ActualStartDate { get; set; }

		[Column("actualEndDate", TypeName="datetime")]
		public Nullable<DateTime> ActualEndDate { get; set; }

		[Column("lessonStatusId", TypeName="int")]
		public int LessonStatusId { get; set; }

		[Column("teacherNotes", TypeName="text(2147483647)")]
		public string TeacherNotes { get; set; }

		[Column("studentNotes", TypeName="text(2147483647)")]
		public string StudentNotes { get; set; }

		[Column("billAmount", TypeName="money")]
		public Nullable<decimal> BillAmount { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("LessonStatusId")]
		public virtual EFLessonStatus LessonStatus { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>87fbd68bb690e6f04f064929ab092e5b</Hash>
</Codenesium>*/