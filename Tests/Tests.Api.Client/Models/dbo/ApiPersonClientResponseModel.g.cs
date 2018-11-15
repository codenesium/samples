using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiPersonClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int personId,
			string personName)
		{
			this.PersonId = personId;
			this.PersonName = personName;
		}

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8ea7504b1a1e7ce52ed01e2394303207</Hash>
</Codenesium>*/