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
		public string PersonEntity { get; private set; } = RouteConstants.People;

		[JsonProperty]
		public ApiPersonServerResponseModel PersonNavigation { get; private set; }

		public void SetPersonNavigation(ApiPersonServerResponseModel value)
		{
			this.PersonNavigation = value;
		}

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonIdEntity { get; private set; } = RouteConstants.People;

		[JsonProperty]
		public ApiPersonServerResponseModel PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(ApiPersonServerResponseModel value)
		{
			this.PersonIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>8ddf7cda0719788348f02373216c24ed</Hash>
</Codenesium>*/