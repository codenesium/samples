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

		public int Id { get; private set; }

		public DateTime? ActualEndDate { get; private set; }

		public DateTime? ActualStartDate { get; private set; }

		public decimal? BillAmount { get; private set; }

		public int LessonStatusId { get; private set; }

		public DateTime? ScheduledEndDate { get; private set; }

		public DateTime? ScheduledStartDate { get; private set; }

		public string StudentNote { get; private set; }

		public string TeacherNote { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a36cc21f263c51ed4588b4a5d2d397f0</Hash>
</Codenesium>*/