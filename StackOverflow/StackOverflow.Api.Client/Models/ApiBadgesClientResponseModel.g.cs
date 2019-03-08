using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiBadgesClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime date,
			string name,
			int userId)
		{
			this.Id = id;
			this.Date = date;
			this.Name = name;
			this.UserId = userId;

			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public ApiUsersClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersClientResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>0e838fd4685bf5afff89c193d1a4fcec</Hash>
</Codenesium>*/