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
			int subscriptionId)
		{
			this.Email = email;
			this.Password = password;
			this.SubscriptionId = subscriptionId;
		}

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int SubscriptionId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8a7009d867e46a8c923031374fe71c77</Hash>
</Codenesium>*/