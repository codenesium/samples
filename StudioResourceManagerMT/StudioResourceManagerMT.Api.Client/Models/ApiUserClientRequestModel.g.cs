using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>8df4ed133e552632eada2c92814179f9</Hash>
</Codenesium>*/