using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiEventClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEventClientRequestModel()
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
			string studentNote,
			string teacherNote)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.EventStatusId = eventStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNote = studentNote;
			this.TeacherNote = teacherNote;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; } = null;

		[JsonProperty]
		public decimal? BillAmount { get; private set; } = default(decimal);

		[JsonProperty]
		public int EventStatusId { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; } = null;

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; } = null;

		[JsonProperty]
		public string StudentNote { get; private set; } = default(string);

		[JsonProperty]
		public string TeacherNote { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>bc45d84f48cdb1ea996aa9cd870a4fa4</Hash>
</Codenesium>*/