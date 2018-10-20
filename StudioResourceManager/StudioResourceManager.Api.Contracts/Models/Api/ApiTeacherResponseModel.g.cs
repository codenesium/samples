using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiTeacherResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId,
			bool isDeleted)
		{
			this.Id = id;
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
			this.IsDeleted = isDeleted;

			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public DateTime Birthday { get; private set; }

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
		public string Phone { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c72d53c5e7f61856d3754ca33eec3524</Hash>
</Codenesium>*/