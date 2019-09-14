using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventTeacherClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int eventId,
			int teacherId)
		{
			this.Id = id;
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
		public int Id { get; private set; }

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>b1db80dcf67c69b08d69deaedd56bff9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/