using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiCompositePrimaryKeyResponseModel : AbstractApiResponseModel
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
    <Hash>a6f8c12b20fd28fea68ee43068be1217</Hash>
</Codenesium>*/