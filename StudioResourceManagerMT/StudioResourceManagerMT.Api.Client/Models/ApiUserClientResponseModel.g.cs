using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiUserClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string password,
			string username)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Password { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1ddf75804e260023ecf9cb9fd56c9f7f</Hash>
</Codenesium>*/