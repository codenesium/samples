using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventStudentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int eventId,
			int studentId)
		{
			this.Id = id;
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
		public int Id { get; private set; }

		[JsonProperty]
		public int StudentId { get; private set; }

		[JsonProperty]
		public string StudentIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>e25d3e081f966bdb099d9ca690dbcd39</Hash>
</Codenesium>*/