using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiAdminServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiAdminServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string email,
			string firstName,
			string lastName,
			string password,
			string phone,
			string username)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
			this.Phone = phone;
			this.Username = username;
		}

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Username { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>540d9d0ff218b5378bf92d549a36d19e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/