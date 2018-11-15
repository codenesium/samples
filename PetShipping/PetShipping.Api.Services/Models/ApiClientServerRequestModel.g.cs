using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiClientServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiClientServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>2c55896a58ce3b26a91c1b04f224f3ad</Hash>
</Codenesium>*/