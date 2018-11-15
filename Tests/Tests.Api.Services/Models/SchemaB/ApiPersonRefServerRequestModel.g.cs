using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiPersonRefServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPersonRefServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int PersonAId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PersonBId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>c33859ea928c843b8934b43ae53e2b21</Hash>
</Codenesium>*/