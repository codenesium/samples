using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiUserResponseModel : AbstractApiResponseModel
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
    <Hash>11c9262f4a3a82d910f4b45d60a64c75</Hash>
</Codenesium>*/