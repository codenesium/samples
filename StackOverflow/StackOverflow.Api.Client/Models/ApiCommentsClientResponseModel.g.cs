using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiCommentsClientResponseModel : AbstractApiClientResponseModel
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

			this.PostIdEntity = nameof(ApiResponse.Posts);

			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public ApiPostsClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiUsersClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersClientResponseModel value)
		{
			this.UserIdNavigation = value;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; set; }

		[JsonProperty]
		public int? Score { get; private set; }

		[JsonProperty]
		public string Text { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>8ad55ca76410dca3a843693e31456a75</Hash>
</Codenesium>*/