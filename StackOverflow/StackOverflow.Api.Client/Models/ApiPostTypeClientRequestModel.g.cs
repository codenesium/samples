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
			string type)
		{
			this.Type = type;
		}

		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>bc89d1989bfe69c633a54e06334cf2d1</Hash>
</Codenesium>*/