using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiVEventResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate,
			bool isDeleted)
		{
			this.Id = id;
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[Required]
		[JsonProperty]
		public decimal? BillAmount { get; private set; }

		[JsonProperty]
		public int EventStatusId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>000a8f614bc706d79534b2bee46bc6d0</Hash>
</Codenesium>*/