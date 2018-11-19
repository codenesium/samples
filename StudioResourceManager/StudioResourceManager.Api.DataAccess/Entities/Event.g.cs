using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("Event", Schema="dbo")]
	public partial class Event : AbstractEntity
	{
		public Event()
		{
		}

		public virtual void SetProperties(
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			int id,
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

		[Column("actualEndDate")]
		public virtual DateTime? ActualEndDate { get; private set; }

		[Column("actualStartDate")]
		public virtual DateTime? ActualStartDate { get; private set; }

		[Column("billAmount")]
		public virtual decimal? BillAmount { get; private set; }

		[Column("eventStatusId")]
		public virtual int EventStatusId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("scheduledEndDate")]
		public virtual DateTime? ScheduledEndDate { get; private set; }

		[Column("scheduledStartDate")]
		public virtual DateTime? ScheduledStartDate { get; private set; }

		[MaxLength(2147483647)]
		[Column("studentNotes")]
		public virtual string StudentNote { get; private set; }

		[MaxLength(2147483647)]
		[Column("teacherNotes")]
		public virtual string TeacherNote { get; private set; }

		[ForeignKey("EventStatusId")]
		public virtual EventStatu EventStatuNavigation { get; private set; }

		public void SetEventStatuNavigation(EventStatu item)
		{
			this.EventStatuNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>dedeae18aae56c5f00ee547a3348cde5</Hash>
</Codenesium>*/