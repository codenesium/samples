using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiUserClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string email,
			string password,
			int subscriptionId)
		{
			this.Id = id;
			this.Email = email;
			this.Password = password;
			this.SubscriptionId = subscriptionId;

			this.SubscriptionIdEntity = nameof(ApiResponse.Subscriptions);
		}

		[JsonProperty]
		public ApiSubscriptionClientResponseModel SubscriptionIdNavigation { get; private set; }

		public void SetSubscriptionIdNavigation(ApiSubscriptionClientResponseModel value)
		{
			this.SubscriptionIdNavigation = value;
		}

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Password { get; private set; }

		[JsonProperty]
		public int SubscriptionId { get; private set; }

		[JsonProperty]
		public string SubscriptionIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>2895c543943233b6171f578229b48277</Hash>
</Codenesium>*/