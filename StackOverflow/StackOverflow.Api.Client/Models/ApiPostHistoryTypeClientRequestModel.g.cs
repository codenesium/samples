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
			string rwtype)
		{
			this.Type = rwtype;
		}

		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>54ceecede751480641158e06b782b592</Hash>
</Codenesium>*/