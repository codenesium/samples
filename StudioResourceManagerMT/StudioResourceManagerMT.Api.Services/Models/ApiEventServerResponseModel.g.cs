using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventServerResponseModel : AbstractApiServerResponseModel
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
		public string EventStatusIdEntity { get; private set; } = RouteConstants.EventStatus;

		[JsonProperty]
		public ApiEventStatusServerResponseModel EventStatusIdNavigation { get; private set; }

		public void SetEventStatusIdNavigation(ApiEventStatusServerResponseModel value)
		{
			this.EventStatusIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }

		[Required]
		[JsonProperty]
		public string StudentNotes { get; private set; }

		[Required]
		[JsonProperty]
		public string TeacherNotes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4682ab1d44e339fc578bbf4ac0203f9c</Hash>
</Codenesium>*/