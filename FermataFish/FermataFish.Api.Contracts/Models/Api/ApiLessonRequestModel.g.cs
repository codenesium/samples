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
			string studentNote,
			string teacherNote,
			int studioId)
		{
			this.ActualEndDate = actualEndDate;
			this.ActualStartDate = actualStartDate;
			this.BillAmount = billAmount;
			this.LessonStatusId = lessonStatusId;
			this.ScheduledEndDate = scheduledEndDate;
			this.ScheduledStartDate = scheduledStartDate;
			this.StudentNote = studentNote;
			this.TeacherNote = teacherNote;
			this.StudioId = studioId;
		}

		[JsonProperty]
		public DateTime? ActualEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ActualStartDate { get; private set; }

		[JsonProperty]
		public decimal? BillAmount { get; private set; }

		[Required]
		[JsonProperty]
		public int LessonStatusId { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledEndDate { get; private set; }

		[JsonProperty]
		public DateTime? ScheduledStartDate { get; private set; }

		[JsonProperty]
		public string StudentNote { get; private set; }

		[JsonProperty]
		public string TeacherNote { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5baa0f4cbca5751f7475207bd3f97830</Hash>
</Codenesium>*/