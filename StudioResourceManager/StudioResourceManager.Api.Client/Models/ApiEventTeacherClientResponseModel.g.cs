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

			this.IdEntity = nameof(ApiResponse.Events);

			this.TeacherIdEntity = nameof(ApiResponse.Teachers);
		}

		[JsonProperty]
		public ApiEventClientResponseModel IdNavigation { get; private set; }

		public void SetIdNavigation(ApiEventClientResponseModel value)
		{
			this.IdNavigation = value;
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
		public int Id { get; private set; }

		[JsonProperty]
		public string IdEntity { get; set; }

		[JsonProperty]
		public int TeacherId { get; private set; }

		[JsonProperty]
		public string TeacherIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>1f13b6e9b530a8fe8a46ec52a54d4060</Hash>
</Codenesium>*/