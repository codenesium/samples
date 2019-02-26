using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiUserServerResponseModel : AbstractApiServerResponseModel
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
		public string SubscriptionIdEntity { get; private set; } = RouteConstants.Subscriptions;

		[JsonProperty]
		public ApiSubscriptionServerResponseModel SubscriptionIdNavigation { get; private set; }

		public void SetSubscriptionIdNavigation(ApiSubscriptionServerResponseModel value)
		{
			this.SubscriptionIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>95295efbe1a88078c8e343692768e622</Hash>
</Codenesium>*/