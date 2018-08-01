using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonRequestModel : AbstractApiRequestModel
	{
		public ApiLessonRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? actualEndDate,
			DateTime? actualStartDate,
			decimal? billAmount,
			int lessonStatusId,
			DateTime? scheduledEndDate,
			DateTime? scheduledStartDate,
			string studentNotes,
			int studioId,
			string teacherNotes)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.LessonStatusId = lessonStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNotes = studentNotes;
			this.StudioId = studioId;
			this.TeacherNotes = teacherNotes;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[JsonProperty]
		public decimal? BillAmount { get; private set; }

		[JsonProperty]
		public int LessonStatusId { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }

		[JsonProperty]
		public string StudentNotes { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string TeacherNotes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>742adb21102659d3fb4ac76d98aa0d4c</Hash>
</Codenesium>*/