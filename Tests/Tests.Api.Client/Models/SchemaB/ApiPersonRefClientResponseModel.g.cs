using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiPersonRefClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>3f3d94e09d6fb9d9762c2059742e3d75</Hash>
</Codenesium>*/