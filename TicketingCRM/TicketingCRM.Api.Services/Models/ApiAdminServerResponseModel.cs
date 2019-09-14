using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiAdminServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>43192bd71d0edceaa22494035dc2e615</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/