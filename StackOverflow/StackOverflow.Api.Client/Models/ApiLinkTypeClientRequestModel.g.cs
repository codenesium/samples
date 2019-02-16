using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiLinkTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiLinkTypeClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string rwType)
		{
			this.RwType = rwType;
		}

		[JsonProperty]
		public string RwType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>e5ac014e69357005dde8e2b05ba1fa4b</Hash>
</Codenesium>*/