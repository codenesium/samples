using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiUserClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUserClientRequestModel()
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

		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[JsonProperty]
		public string Username { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>7bb6eb1e56f6cb6359ea8bf637aff564</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/