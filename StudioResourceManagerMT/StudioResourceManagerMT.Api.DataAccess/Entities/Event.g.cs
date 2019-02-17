using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Event", Schema="dbo")]
	public partial class Event : AbstractEntity
	{
		public Event()
		{
		}

		public virtual void SetProperties(
			int id,
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate,
			string studentNote,
			string teacherNote)
		{
			this.Id = id;
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
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
		public virtual EventStatu EventStatusIdNavigation { get; private set; }

		public void SetEventStatusIdNavigation(EventStatu item)
		{
			this.EventStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e72eeb087c52dc48a45abd6b5cce362f</Hash>
</Codenesium>*/