using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventTeacherResponseModel : AbstractApiResponseModel
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
    <Hash>3b748760c6ee8019c4c9ee98694df4b0</Hash>
</Codenesium>*/