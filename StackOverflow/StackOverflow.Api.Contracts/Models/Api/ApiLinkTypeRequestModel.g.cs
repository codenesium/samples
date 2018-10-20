using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiLinkTypeRequestModel : AbstractApiRequestModel
	{
		public ApiLinkTypeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string type)
		{
			this.Type = type;
		}

		[Required]
		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>6f5914fda937a84e8d4ef7a00c29557e</Hash>
</Codenesium>*/