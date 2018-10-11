using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("vEvents", Schema="dbo")]
	public partial class VEvent : AbstractEntity
	{
		public VEvent()
		{
		}

		public virtual void SetProperties(
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			int id,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.Id = id;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("scheduledEndDate")]
		public DateTime? ScheduledEndDate { get; private set; }

		[Column("scheduledStartDate")]
		public DateTime? ScheduledStartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9ac03946f97eea660e6915f9a32989f2</Hash>
</Codenesium>*/