using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime? ActualEndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; } = null;

		[JsonProperty]
		public decimal? BillAmount { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int EventStatusId { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; } = null;
	}
}

/*<Codenesium>
    <Hash>5214e4353c545650765652dff86debb7</Hash>
</Codenesium>*/