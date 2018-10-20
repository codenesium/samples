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
			int studentId,
			bool isDeleted)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
			this.IsDeleted = isDeleted;

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

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4975b312b6e05aaf517d3de0c12786e9</Hash>
</Codenesium>*/