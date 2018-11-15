using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiCompositePrimaryKeyClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCompositePrimaryKeyClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int id2)
		{
			this.Id2 = id2;
		}

		[JsonProperty]
		public int Id2 { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>b2e11a87f4bff0c6923405cf1a2a91b6</Hash>
</Codenesium>*/