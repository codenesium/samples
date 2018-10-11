using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiVEventRequestModel : AbstractApiRequestModel
	{
		public ApiVEventRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[JsonProperty]
		public decimal? BillAmount { get; private set; }

		[Required]
		[JsonProperty]
		public int EventStatusId { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f13360ba1c051e055be65fa8a1e2b0c2</Hash>
</Codenesium>*/