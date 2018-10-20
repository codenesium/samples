using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOVEvent : AbstractBusinessObject
	{
		public AbstractBOVEvent()
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
		                                  bool isDeleted)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.Id = id;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.IsDeleted = isDeleted;
		}

		public DateTime? ActualEndDate { get; private set; }

		public DateTime? ActualStartDate { get; private set; }

		public decimal? BillAmount { get; private set; }

		public int EventStatusId { get; private set; }

		public int Id { get; private set; }

		public DateTime? ScheduledEndDate { get; private set; }

		public DateTime? ScheduledStartDate { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bd0d8127b2f696e2761068eec961d995</Hash>
</Codenesium>*/