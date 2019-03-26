using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerCapabilityClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiOfficerCapabilityClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int officerId)
		{
			this.OfficerId = officerId;
		}

		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7fca5e0fb8d369b46a3b06c446e59423</Hash>
</Codenesium>*/