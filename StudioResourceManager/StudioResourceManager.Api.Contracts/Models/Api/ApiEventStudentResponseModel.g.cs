using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventStudentResponseModel : AbstractApiResponseModel
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
    <Hash>a6924ca9b9477c634319e34a2612b6c9</Hash>
</Codenesium>*/