using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiEventTeacherServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventTeacherServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int eventId,
			int teacherId)
		{
			this.EventId = eventId;
			this.TeacherId = teacherId;
		}

		[Required]
		[JsonProperty]
		public int EventId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0bb15f7d38d19edd55257988ef44f245</Hash>
</Codenesium>*/