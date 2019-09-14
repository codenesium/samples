using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>0e2554413a289cb661686d2acd43e404</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/