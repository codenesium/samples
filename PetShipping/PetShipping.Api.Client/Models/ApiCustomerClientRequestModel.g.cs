using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCustomerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCustomerClientRequestModel()
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
    <Hash>09ac1fd610519db5503c2f934c66eb1d</Hash>
</Codenesium>*/