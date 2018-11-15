using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiColumnSameAsFKTableServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>615bc79cd86110375bb549e7d0a90443</Hash>
</Codenesium>*/