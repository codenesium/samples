using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCustomerClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string note,
			string phone)
		{
			this.Id = id;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Note = note;
			this.Phone = phone;
		}

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>93f9648436dd889bcf1e95f45e6e07ed</Hash>
</Codenesium>*/