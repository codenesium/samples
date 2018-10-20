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
			int teacherId,
			bool isDeleted)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
			this.IsDeleted = isDeleted;

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

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8af9e81ea61676d6d2ae14b1b7fce532</Hash>
</Codenesium>*/