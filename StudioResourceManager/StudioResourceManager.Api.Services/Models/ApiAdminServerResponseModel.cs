using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiAdminServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime? birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId)
		{
			this.Id = id;
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public DateTime? Birthday { get; private set; }

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
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>a15a7c35e1aa7f801c0eff1df7041b79</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/