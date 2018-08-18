using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOLesson : AbstractBusinessObject
	{
		public AbstractBOLesson()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? actualEndDate,
		                                  DateTime? actualStartDate,
		                                  decimal? billAmount,
		                                  int lessonStatusId,
		                                  DateTime? scheduledEndDate,
		                                  DateTime? scheduledStartDate,
		                                  string studentNotes,
		                                  int studioId,
		                                  string teacherNotes)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.Id = id;
			this.LessonStatusId = lessonStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNotes = studentNotes;
			this.StudioId = studioId;
			this.TeacherNotes = teacherNotes;
		}

		public DateTime? ActualEndDate { get; private set; }

		public DateTime? ActualStartDate { get; private set; }

		public decimal? BillAmount { get; private set; }

		public int Id { get; private set; }

		public int LessonStatusId { get; private set; }

		public DateTime? ScheduledEndDate { get; private set; }

		public DateTime? ScheduledStartDate { get; private set; }

		public string StudentNotes { get; private set; }

		public int StudioId { get; private set; }

		public string TeacherNotes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fe1dd43c77c957561b2af9b04ef5acce</Hash>
</Codenesium>*/