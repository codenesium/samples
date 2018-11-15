using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiClientClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiClientClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string email,
			string firstName,
			string lastName,
			string note,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Note = note;
			this.Phone = phone;
		}

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f7914fbca8beb6b6342d38bf4ecf5024</Hash>
</Codenesium>*/