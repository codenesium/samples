using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiHandlerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1174e8972b4a8ef85c36c0cbb43cda67</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/