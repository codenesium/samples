using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostHistoryTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostHistoryTypeClientRequestModel()
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
    <Hash>e1c63cee75491487f318a86226dfd395</Hash>
</Codenesium>*/