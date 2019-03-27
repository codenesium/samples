using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiSubscriptionClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			string stripePlanName)
		{
			this.Id = id;
			this.Name = name;
			this.StripePlanName = stripePlanName;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string StripePlanName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>80d25c788dac6ce7a3b03ab328414027</Hash>
</Codenesium>*/