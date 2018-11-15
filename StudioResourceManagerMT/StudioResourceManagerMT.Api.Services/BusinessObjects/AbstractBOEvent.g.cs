using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBOEvent : AbstractBusinessObject
	{
		public AbstractBOEvent()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? actualEndDate,
		                                  DateTime? actualStartDate,
		                                  decimal? billAmount,
		                                  int eventStatusId,
		                                  DateTime? scheduledEndDate,
		                                  DateTime? scheduledStartDate,
		                                  string studentNote,
		                                  string teacherNote)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.Id = id;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNote = studentNote;
			this.TeacherNote = teacherNote;
		}

		public DateTime? ActualEndDate { get; private set; }

		public DateTime? ActualStartDate { get; private set; }

		public decimal? BillAmount { get; private set; }

		public int EventStatusId { get; private set; }

		public int Id { get; private set; }

		public DateTime? ScheduledEndDate { get; private set; }

		public DateTime? ScheduledStartDate { get; private set; }

		public string StudentNote { get; private set; }

		public string TeacherNote { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad98cecc61b16c1374cd206a0d67e6f9</Hash>
</Codenesium>*/