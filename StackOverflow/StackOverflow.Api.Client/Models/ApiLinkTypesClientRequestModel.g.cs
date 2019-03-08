using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiLinkTypesClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiLinkTypesClientRequestModel()
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
    <Hash>ba48809fee578b495e46b6b982006ed2</Hash>
</Codenesium>*/