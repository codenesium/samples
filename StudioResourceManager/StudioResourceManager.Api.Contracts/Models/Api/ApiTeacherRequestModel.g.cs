using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiTeacherRequestModel : AbstractApiRequestModel
	{
		public ApiTeacherRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId,
			bool isDeleted)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public DateTime Birthday { get; private set; } = default(DateTime);

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
		public int UserId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>740c61f7fcee1e5f82e5d47655a09622</Hash>
</Codenesium>*/