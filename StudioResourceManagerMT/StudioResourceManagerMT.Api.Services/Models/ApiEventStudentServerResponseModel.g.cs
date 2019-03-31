using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventStudentServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int eventId,
			int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
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
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; private set; } = RouteConstants.Students;

		[JsonProperty]
		public ApiStudentServerResponseModel StudentIdNavigation { get; private set; }

		public void SetStudentIdNavigation(ApiStudentServerResponseModel value)
		{
			this.StudentIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>1196e62abbcbfe0942c1ccee381699d4</Hash>
</Codenesium>*/