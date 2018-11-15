using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiClientServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ca299844471a91e85f51670bf98df298</Hash>
</Codenesium>*/