using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiHandlerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiHandlerServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>2160ef1c3bcc2e858d4e0af0d02436a9</Hash>
</Codenesium>*/