using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiPersonRefClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPersonRefClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int personAId,
			int personBId)
		{
			this.PersonAId = personAId;
			this.PersonBId = personBId;
		}

		[JsonProperty]
		public int PersonAId { get; private set; } = default(int);

		[JsonProperty]
		public int PersonBId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>c5d02afbd2a8f6f43016711ab682355c</Hash>
</Codenesium>*/