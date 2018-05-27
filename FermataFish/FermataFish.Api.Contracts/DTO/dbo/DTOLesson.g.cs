using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOLesson: AbstractDTO
	{
		public DTOLesson() : base()
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

		public Nullable<DateTime> ActualEndDate { get; set; }
		public Nullable<DateTime> ActualStartDate { get; set; }
		public Nullable<decimal> BillAmount { get; set; }
		public int Id { get; set; }
		public int LessonStatusId { get; set; }
		public Nullable<DateTime> ScheduledEndDate { get; set; }
		public Nullable<DateTime> ScheduledStartDate { get; set; }
		public string StudentNotes { get; set; }
		public int StudioId { get; set; }
		public string TeacherNotes { get; set; }
	}
}

/*<Codenesium>
    <Hash>46d0eadd19e374c619f9f4e92e939d75</Hash>
</Codenesium>*/