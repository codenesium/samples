using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
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
		public int EventId { get; private set; }

		[Required]
		[JsonProperty]
		public int TeacherId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>191ebeae01981b71e1bf1dc2a4af8a17</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/