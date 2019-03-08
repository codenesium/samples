using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostHistoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string comment,
			DateTime creationDate,
			int postHistoryTypeId,
			int postId,
			string revisionGUID,
			string text,
			string userDisplayName,
			int? userId)
		{
			this.Id = id;
			this.Comment = comment;
			this.CreationDate = creationDate;
			this.PostHistoryTypeId = postHistoryTypeId;
			this.PostId = postId;
			this.RevisionGUID = revisionGUID;
			this.Text = text;
			this.UserDisplayName = userDisplayName;
			this.UserId = userId;

			this.PostHistoryTypeIdEntity = nameof(ApiResponse.PostHistoryTypes);

			this.PostIdEntity = nameof(ApiResponse.Posts);

			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public ApiPostHistoryTypesClientResponseModel PostHistoryTypeIdNavigation { get; private set; }

		public void SetPostHistoryTypeIdNavigation(ApiPostHistoryTypesClientResponseModel value)
		{
			this.PostHistoryTypeIdNavigation = value;
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
		public string Comment { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostHistoryTypeId { get; private set; }

		[JsonProperty]
		public string PostHistoryTypeIdEntity { get; set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; set; }

		[JsonProperty]
		public string RevisionGUID { get; private set; }

		[JsonProperty]
		public string Text { get; private set; }

		[JsonProperty]
		public string UserDisplayName { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>581d4a006a0d31887503cb0533e9aa5c</Hash>
</Codenesium>*/