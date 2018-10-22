using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiUserRequestModel : AbstractApiRequestModel
	{
		public ApiUserRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string password,
			string username)
		{
			this.Password = password;
			this.Username = username;
		}

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Username { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>431d425d42948dc71f5587d269475196</Hash>
</Codenesium>*/