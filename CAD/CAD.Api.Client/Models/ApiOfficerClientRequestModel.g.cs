using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiOfficerClientRequestModel()
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

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Password { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9919e8e9db2c615e223bf3b22e06d410</Hash>
</Codenesium>*/