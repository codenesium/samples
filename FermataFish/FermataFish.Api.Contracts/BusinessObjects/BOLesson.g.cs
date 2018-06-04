using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOLesson: AbstractBusinessObject
	{
		public BOLesson() : base()
		{}

		public void SetProperties(int id,
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
			this.StudentNotes = studentNotes;
			this.StudioId = studioId.ToInt();
			this.TeacherNotes = teacherNotes;
		}

		public Nullable<DateTime> ActualEndDate { get; private set; }
		public Nullable<DateTime> ActualStartDate { get; private set; }
		public Nullable<decimal> BillAmount { get; private set; }
		public int Id { get; private set; }
		public int LessonStatusId { get; private set; }
		public Nullable<DateTime> ScheduledEndDate { get; private set; }
		public Nullable<DateTime> ScheduledStartDate { get; private set; }
		public string StudentNotes { get; private set; }
		public int StudioId { get; private set; }
		public string TeacherNotes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ca71ba091941bf98d74d5dd7c0a20640</Hash>
</Codenesium>*/