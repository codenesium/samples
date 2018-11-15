using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiAdminClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string password,
			string phone,
			string username)
		{
			this.Id = id;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
			this.Phone = phone;
			this.Username = username;
		}

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

		[JsonProperty]
		public string Phone { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4a5675c0979aa7f6fcea77e86b67a434</Hash>
</Codenesium>*/