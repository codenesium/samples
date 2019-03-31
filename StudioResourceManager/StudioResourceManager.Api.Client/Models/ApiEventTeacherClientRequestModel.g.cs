using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventTeacherClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEventTeacherClientRequestModel()
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

		[JsonProperty]
		public int EventId { get; private set; }

		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2abaf8355f3589e28f867490d36f8b4a</Hash>
</Codenesium>*/