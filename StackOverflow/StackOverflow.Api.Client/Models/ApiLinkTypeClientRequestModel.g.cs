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
			string type)
		{
			this.Type = type;
		}

		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f12d56583f4895e409e90a061d07e0ab</Hash>
</Codenesium>*/