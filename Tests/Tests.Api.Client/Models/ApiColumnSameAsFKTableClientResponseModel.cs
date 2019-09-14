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
		public ApiPersonClientResponseModel PersonNavigation { get; private set; }

		public void SetPersonNavigation(ApiPersonClientResponseModel value)
		{
			this.PersonNavigation = value;
		}

		[JsonProperty]
		public ApiPersonClientResponseModel PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(ApiPersonClientResponseModel value)
		{
			this.PersonIdNavigation = value;
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
    <Hash>1aeddd06f9787e5802ddaff88dae3c64</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/