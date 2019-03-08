using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiCommentsServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime creationDate,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? Score { get; private set; }

		[JsonProperty]
		public string Text { get; private set; }

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUsersServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>29d979dff082c839b555a5b31a5f1ba2</Hash>
</Codenesium>*/