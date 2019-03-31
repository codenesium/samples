using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiEventTeacherClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int eventId,
			int teacherId)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;

			this.EventIdEntity = nameof(ApiResponse.Events);

			this.TeacherIdEntity = nameof(ApiResponse.Teachers);
		}

		[JsonProperty]
		public ApiEventClientResponseModel EventIdNavigation { get; private set; }

		public void SetEventIdNavigation(ApiEventClientResponseModel value)
		{
			this.EventIdNavigation = value;
		}

		[JsonProperty]
		public ApiTeacherClientResponseModel TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(ApiTeacherClientResponseModel value)
		{
			this.TeacherIdNavigation = value;
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public string EventIdEntity { get; set; }

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>f4aaa477e2d656e785f136eae28c479f</Hash>
</Codenesium>*/