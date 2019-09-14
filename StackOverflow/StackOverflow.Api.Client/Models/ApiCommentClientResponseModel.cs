using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiCommentClientResponseModel : AbstractApiClientResponseModel
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
		public ApiPostClientResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostClientResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public ApiUserClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserClientResponseModel value)
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
    <Hash>6e1a6e11fdbfc5f7c6a1ba6693c13f8b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/