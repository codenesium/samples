using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiCompositePrimaryKeyRequestModel : AbstractApiRequestModel
	{
		public ApiCompositePrimaryKeyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int id2)
		{
			this.Id2 = id2;
		}

		[Required]
		[JsonProperty]
		public int Id2 { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>48891a25c5703fa47cf8956a90929aed</Hash>
</Codenesium>*/