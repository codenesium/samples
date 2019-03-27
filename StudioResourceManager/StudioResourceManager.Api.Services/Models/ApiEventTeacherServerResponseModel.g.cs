using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiEventTeacherServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int eventId,
			int teacherId)
		{
			this.Id = id;
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string IdEntity { get; private set; } = RouteConstants.Events;

		[JsonProperty]
		public ApiEventServerResponseModel IdNavigation { get; private set; }

		public void SetIdNavigation(ApiEventServerResponseModel value)
		{
			this.IdNavigation = value;
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
    <Hash>5c4dfbbdea76b780cf837dc69e683394</Hash>
</Codenesium>*/