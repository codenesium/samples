using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiCompositePrimaryKeyClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int id2)
		{
			this.Id = id;
			this.Id2 = id2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96595b2ce546726e1e97358eccf14598</Hash>
</Codenesium>*/