using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiPersonRefResponseModel : AbstractApiResponseModel
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
    <Hash>b9de38c6501fa5847d6e126586650323</Hash>
</Codenesium>*/