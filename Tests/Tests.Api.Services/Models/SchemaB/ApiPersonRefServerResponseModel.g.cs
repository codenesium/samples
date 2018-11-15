using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiPersonRefServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int personAId,
			int personBId)
		{
			this.Id = id;
			this.PersonAId = personAId;
			this.PersonBId = personBId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PersonAId { get; private set; }

		[JsonProperty]
		public int PersonBId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9bd6336f278a05167cd86d10b909850f</Hash>
</Codenesium>*/