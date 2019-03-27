using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventTeacherServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int eventId,
			int teacherId)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public string EventIdEntity { get; private set; } = RouteConstants.Events;

		[JsonProperty]
		public ApiEventServerResponseModel EventIdNavigation { get; private set; }

		public void SetEventIdNavigation(ApiEventServerResponseModel value)
		{
			this.EventIdNavigation = value;
		}

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; private set; } = RouteConstants.Teachers;

		[JsonProperty]
		public ApiTeacherServerResponseModel TeacherIdNavigation { get; private set; }

		public void SetTeacherIdNavigation(ApiTeacherServerResponseModel value)
		{
			this.TeacherIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>da7e2b0f549d4aab13fa3d949cb94ad3</Hash>
</Codenesium>*/