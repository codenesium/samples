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
			int subscriptionId)
		{
			this.Email = email;
			this.Password = password;
			this.SubscriptionId = subscriptionId;
		}

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[JsonProperty]
		public int SubscriptionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>66e00cad5d30839eacfb81b2da311e34</Hash>
</Codenesium>*/