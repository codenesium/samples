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
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int Person { get; private set; }

		[JsonProperty]
		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6263f8c2c16840e553bac5582194ff4e</Hash>
</Codenesium>*/