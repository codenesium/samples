using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiUserClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUserClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string email,
			string password,
			string stripeCustomerId,
			int subscriptionTypeId)
		{
			this.Email = email;
			this.Password = password;
			this.StripeCustomerId = stripeCustomerId;
			this.SubscriptionTypeId = subscriptionTypeId;
		}

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[JsonProperty]
		public string StripeCustomerId { get; private set; } = default(string);

		[JsonProperty]
		public int SubscriptionTypeId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>3570f3fdb79c6a854ea777816fbe345a</Hash>
</Codenesium>*/