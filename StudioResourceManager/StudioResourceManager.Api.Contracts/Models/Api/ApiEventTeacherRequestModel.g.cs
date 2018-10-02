using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventTeacherRequestModel : AbstractApiRequestModel
	{
		public ApiEventTeacherRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int eventId)
		{
			this.EventId = eventId;
		}

		[Required]
		[JsonProperty]
		public int EventId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>df37ece4e91864999bd39d2f150bcd4c</Hash>
</Codenesium>*/