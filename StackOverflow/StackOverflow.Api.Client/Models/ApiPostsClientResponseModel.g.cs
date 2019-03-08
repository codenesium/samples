using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostsClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? acceptedAnswerId,
			int? answerCount,
			string body,
			DateTime? closedDate,
			int? commentCount,
			DateTime? communityOwnedDate,
			DateTime creationDate,
			int? favoriteCount,
			DateTime lastActivityDate,
			DateTime? lastEditDate,
			string lastEditorDisplayName,
			int? lastEditorUserId,
			int? ownerUserId,
			int? parentId,
			int postTypeId,
			int score,
			string tag,
			string title,
			int viewCount)
		{
			this.Id = id;
			this.AcceptedAnswerId = acceptedAnswerId;
			this.AnswerCount = answerCount;
			this.Body = body;
			this.ClosedDate = closedDate;
			this.CommentCount = commentCount;
			this.CommunityOwnedDate = communityOwnedDate;
			this.CreationDate = creationDate;
			this.FavoriteCount = favoriteCount;
			this.LastActivityDate = lastActivityDate;
			this.LastEditDate = lastEditDate;
			this.LastEditorDisplayName = lastEditorDisplayName;
			this.LastEditorUserId = lastEditorUserId;
			this.OwnerUserId = ownerUserId;
			this.ParentId = parentId;
			this.PostTypeId = postTypeId;
			this.Score = score;
			this.Tag = tag;
			this.Title = title;
			this.ViewCount = viewCount;

			this.LastEditorUserIdEntity = nameof(ApiResponse.Users);

			this.OwnerUserIdEntity = nameof(ApiResponse.Users);

			this.ParentIdEntity = nameof(ApiResponse.Posts);

			this.PostTypeIdEntity = nameof(ApiResponse.PostTypes);
		}

		[JsonProperty]
		public ApiUsersClientResponseModel LastEditorUserIdNavigation { get; private set; }

		public void SetLastEditorUserIdNavigation(ApiUsersClientResponseModel value)
		{
			this.LastEditorUserIdNavigation = value;
		}

		[JsonProperty]
		public ApiUsersClientResponseModel OwnerUserIdNavigation { get; private set; }

		public void SetOwnerUserIdNavigation(ApiUsersClientResponseModel value)
		{
			this.OwnerUserIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostsClientResponseModel ParentIdNavigation { get; private set; }

		public void SetParentIdNavigation(ApiPostsClientResponseModel value)
		{
			this.ParentIdNavigation = value;
		}

		[JsonProperty]
		public ApiPostTypesClientResponseModel PostTypeIdNavigation { get; private set; }

		public void SetPostTypeIdNavigation(ApiPostTypesClientResponseModel value)
		{
			this.PostTypeIdNavigation = value;
		}

		[JsonProperty]
		public int? AcceptedAnswerId { get; private set; }

		[JsonProperty]
		public int? AnswerCount { get; private set; }

		[JsonProperty]
		public string Body { get; private set; }

		[JsonProperty]
		public DateTime? ClosedDate { get; private set; }

		[JsonProperty]
		public int? CommentCount { get; private set; }

		[JsonProperty]
		public DateTime? CommunityOwnedDate { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int? FavoriteCount { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime LastActivityDate { get; private set; }

		[JsonProperty]
		public DateTime? LastEditDate { get; private set; }

		[JsonProperty]
		public string LastEditorDisplayName { get; private set; }

		[JsonProperty]
		public int? LastEditorUserId { get; private set; }

		[JsonProperty]
		public string LastEditorUserIdEntity { get; set; }

		[JsonProperty]
		public int? OwnerUserId { get; private set; }

		[JsonProperty]
		public string OwnerUserIdEntity { get; set; }

		[JsonProperty]
		public int? ParentId { get; private set; }

		[JsonProperty]
		public string ParentIdEntity { get; set; }

		[JsonProperty]
		public int PostTypeId { get; private set; }

		[JsonProperty]
		public string PostTypeIdEntity { get; set; }

		[JsonProperty]
		public int Score { get; private set; }

		[JsonProperty]
		public string Tag { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }

		[JsonProperty]
		public int ViewCount { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2fd590fdf323812fb11c78663c3fc073</Hash>
</Codenesium>*/