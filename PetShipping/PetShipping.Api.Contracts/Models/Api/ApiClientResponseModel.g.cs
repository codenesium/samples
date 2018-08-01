using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string notes,
			string phone)
		{
			this.Id = id;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
		}

		[Required]
		[JsonProperty]
		public string Email { get; private set; }

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string Notes { get; private set; }

		[Required]
		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>276e3036000940513ec1c1cc2fac7e20</Hash>
</Codenesium>*/