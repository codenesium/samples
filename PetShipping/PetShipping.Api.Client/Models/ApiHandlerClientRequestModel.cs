using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiHandlerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiHandlerClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.CountryId = countryId;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[JsonProperty]
		public int CountryId { get; private set; } = default(int);

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
    <Hash>bdec8cfab7718f34d87cba766951efef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/