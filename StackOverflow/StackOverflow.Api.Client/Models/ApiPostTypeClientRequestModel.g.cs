using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostTypeClientRequestModel()
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
    <Hash>2ccdf15c9f5f3172d036b0bdffe7590e</Hash>
</Codenesium>*/