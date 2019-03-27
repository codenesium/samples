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
			string stripeCustomerId,
			int subscriptionTypeId)
		{
			this.Id = id;
			this.Email = email;
			this.Password = password;
			this.StripeCustomerId = stripeCustomerId;
			this.SubscriptionTypeId = subscriptionTypeId;
		}

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Password { get; private set; }

		[JsonProperty]
		public string StripeCustomerId { get; private set; }

		[JsonProperty]
		public int SubscriptionTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2e099f7c3d266d9085723466c9a464c0</Hash>
</Codenesium>*/