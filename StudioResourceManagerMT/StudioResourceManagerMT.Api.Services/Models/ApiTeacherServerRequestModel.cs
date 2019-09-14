using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiTeacherServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTeacherServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public DateTime Birthday { get; private set; } = SqlDateTime.MinValue.Value;

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
		public string Phone { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bc2e4ba2d3e6bc43dfcdd3ba010c5667</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/