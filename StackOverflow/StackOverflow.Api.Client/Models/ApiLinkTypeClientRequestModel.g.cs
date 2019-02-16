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
			string rwtype)
		{
			this.Type = rwtype;
		}

		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>cf2b231643853757a958dbd617d606cb</Hash>
</Codenesium>*/