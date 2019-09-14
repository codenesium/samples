using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
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
    <Hash>37fcadcf4a645a8e358322b6a16a6b5b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/