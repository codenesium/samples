using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerCapabilitiesClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiOfficerCapabilitiesClientRequestModel()
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
    <Hash>32d3f3bc36d74edd3552a831df3d99a1</Hash>
</Codenesium>*/