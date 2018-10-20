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
			string teacherNote,
			bool isDeleted)
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
			this.IsDeleted = isDeleted;
		}

		[Column("actualEndDate")]
		public DateTime? ActualEndDate { get; private set; }

		[Column("actualStartDate")]
		public DateTime? ActualStartDate { get; private set; }

		[Column("billAmount")]
		public decimal? BillAmount { get; private set; }

		[Column("eventStatusId")]
		public int EventStatusId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

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

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("EventStatusId")]
		public virtual EventStatus EventStatusNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f00fca37550d5ec5e2237c4e82ed1b45</Hash>
</Codenesium>*/