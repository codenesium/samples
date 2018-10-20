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
			DateTime? scheduledStartDate,
			bool isDeleted)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.IsDeleted = isDeleted;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public decimal? BillAmount { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int EventStatusId { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>3baca1d9ff5b88760f6dcfc6ade26185</Hash>
</Codenesium>*/