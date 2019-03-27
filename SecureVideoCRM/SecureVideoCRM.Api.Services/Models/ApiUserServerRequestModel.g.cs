using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiUserServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiUserServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string StripeCustomerId { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int SubscriptionTypeId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>92ff2ca8e36832e19115b80b16cd5761</Hash>
</Codenesium>*/