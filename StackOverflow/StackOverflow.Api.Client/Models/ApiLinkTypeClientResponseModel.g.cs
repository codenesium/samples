using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiLinkTypeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string rwType)
		{
			this.Id = id;
			this.RwType = rwType;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string RwType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4f8dfa83407855077f6a2159b50e3e21</Hash>
</Codenesium>*/