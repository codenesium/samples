using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostTypeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string type)
		{
			this.Id = id;
			this.Type = type;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b3e3167164a41a2b0a3016597e0013a8</Hash>
</Codenesium>*/