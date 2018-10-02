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
			int id,
			int eventId)
		{
			this.Id = id;
			this.EventId = eventId;

			this.EventIdEntity = nameof(ApiResponse.Events);
		}

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public string EventIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8f00ccc0b903a4983a4a7d688f584ea0</Hash>
</Codenesium>*/