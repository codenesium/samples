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
		public string EventStatusIdEntity { get; set; }

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
		public string StudentNote { get; private set; }

		[Required]
		[JsonProperty]
		public string TeacherNote { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e784e99203be02500fab2f551a0c62fa</Hash>
</Codenesium>*/