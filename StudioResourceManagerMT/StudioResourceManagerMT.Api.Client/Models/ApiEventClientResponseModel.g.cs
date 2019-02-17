using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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

			this.EventStatusIdEntity = nameof(ApiResponse.EventStatus);
		}

		[JsonProperty]
		public ApiEventStatuClientResponseModel EventStatusIdNavigation { get; private set; }

		public void SetEventStatusIdNavigation(ApiEventStatuClientResponseModel value)
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
		public string StudentNote { get; private set; }

		[JsonProperty]
		public string TeacherNote { get; private set; }
	}
}

/*<Codenesium>
    <Hash>09e39d40ef767a4aa75ea692e126040b</Hash>
</Codenesium>*/