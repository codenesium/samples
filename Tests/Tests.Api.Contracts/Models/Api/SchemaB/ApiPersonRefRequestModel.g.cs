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
		public int PersonAId { get; private set; }

		[Required]
		[JsonProperty]
		public int PersonBId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8f43ee941993519b8f0530970645d3dc</Hash>
</Codenesium>*/