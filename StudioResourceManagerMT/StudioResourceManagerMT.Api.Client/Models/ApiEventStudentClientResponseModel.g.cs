using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiEventStudentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int eventId,
			int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;

			this.EventIdEntity = nameof(ApiResponse.Events);

			this.StudentIdEntity = nameof(ApiResponse.Students);
		}

		[JsonProperty]
		public ApiEventClientResponseModel EventIdNavigation { get; private set; }

		public void SetEventIdNavigation(ApiEventClientResponseModel value)
		{
			this.EventIdNavigation = value;
		}

		[JsonProperty]
		public ApiStudentClientResponseModel StudentIdNavigation { get; private set; }

		public void SetStudentIdNavigation(ApiStudentClientResponseModel value)
		{
			this.StudentIdNavigation = value;
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public string EventIdEntity { get; set; }

		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>e20bc631f87926493bf1421383a97697</Hash>
</Codenesium>*/