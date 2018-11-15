using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
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
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4f897e93a0cbe81eb22eabd1dfdea5b2</Hash>
</Codenesium>*/