using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int eventStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate,
			string studentNotes,
			string teacherNotes)
		{
			this.Id = id;
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNotes = studentNotes;
			this.TeacherNotes = teacherNotes;

			this.EventStatusIdEntity = nameof(ApiResponse.EventStatus);
		}

		[JsonProperty]
		public ApiEventStatusClientResponseModel EventStatusIdNavigation { get; private set; }

		public void SetEventStatusIdNavigation(ApiEventStatusClientResponseModel value)
		{
			this.EventStatusIdNavigation = value;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[JsonProperty]
		public decimal? BillAmount { get; private set; }

		[JsonProperty]
		public int EventStatusId { get; private set; }

		[JsonProperty]
		public string EventStatusIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }

		[JsonProperty]
		public string StudentNotes { get; private set; }

		[JsonProperty]
		public string TeacherNotes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b0891ffebceb148e70f3368898af2a48</Hash>
</Codenesium>*/