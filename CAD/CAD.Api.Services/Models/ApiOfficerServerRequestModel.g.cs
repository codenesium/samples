using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiOfficerServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string badge,
			string email,
			string firstName,
			string lastName,
			string password)
		{
			this.Badge = badge;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
		}

		[JsonProperty]
		public string Badge { get; private set; } = default(string);

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
	}
}

/*<Codenesium>
    <Hash>5fb85c057326f2be51fe5d7fac8f3473</Hash>
</Codenesium>*/