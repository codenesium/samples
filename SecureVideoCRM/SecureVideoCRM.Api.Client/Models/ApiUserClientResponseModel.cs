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
    <Hash>1a25ba31fbaf54f9a70b0b37d8a398c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/