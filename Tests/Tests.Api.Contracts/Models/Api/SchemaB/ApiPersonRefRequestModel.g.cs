using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiPersonRefRequestModel : AbstractApiRequestModel
	{
		public ApiPersonRefRequestModel()
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
    <Hash>630125c2a49e348c865e19dbb577242e</Hash>
</Codenesium>*/