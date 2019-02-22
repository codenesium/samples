using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string badge,
			string email,
			string firstName,
			string lastName,
			string password)
		{
			this.Id = id;
			this.Badge = badge;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
		}

		[JsonProperty]
		public string Badge { get; private set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Password { get; private set; }
	}
}

/*<Codenesium>
    <Hash>16d054ce4a6dd2acb95872704d6037e4</Hash>
</Codenesium>*/