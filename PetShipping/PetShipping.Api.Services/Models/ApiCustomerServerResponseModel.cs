using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiCustomerServerResponseModel : AbstractApiServerResponseModel
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

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string Notes { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7c10437cd908f3ec278d98891279415b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/