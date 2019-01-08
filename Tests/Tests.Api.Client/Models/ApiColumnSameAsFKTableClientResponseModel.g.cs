using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiColumnSameAsFKTableClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int person,
			int personId)
		{
			this.Id = id;
			this.Person = person;
			this.PersonId = personId;

			this.PersonEntity = nameof(ApiResponse.People);
			this.PersonIdEntity = nameof(ApiResponse.People);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int Person { get; private set; }

		[JsonProperty]
		public string PersonEntity { get; set; }

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>6e4353f4589f5f71123b3cc342115177</Hash>
</Codenesium>*/