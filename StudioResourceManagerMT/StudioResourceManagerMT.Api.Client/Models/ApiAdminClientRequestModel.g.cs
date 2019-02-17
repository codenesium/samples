using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiAdminClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiAdminClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime? Birthday { get; private set; } = null;

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[JsonProperty]
		public int UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>c13ec6a835431773324a09aa85f0c1c3</Hash>
</Codenesium>*/