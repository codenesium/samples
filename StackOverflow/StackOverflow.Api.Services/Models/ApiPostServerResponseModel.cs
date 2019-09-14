using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostServerResponseModel : AbstractApiServerResponseModel
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
		}

		[Required]
		[JsonProperty]
		public int? AcceptedAnswerId { get; private set; }

		[Required]
		[JsonProperty]
		public int? AnswerCount { get; private set; }

		[JsonProperty]
		public string Body { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? ClosedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int? CommentCount { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? CommunityOwnedDate { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[Required]
		[JsonProperty]
		public int? FavoriteCount { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public DateTime LastActivityDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? LastEditDate { get; private set; }

		[Required]
		[JsonProperty]
		public string LastEditorDisplayName { get; private set; }

		[Required]
		[JsonProperty]
		public int? LastEditorUserId { get; private set; }

		[JsonProperty]
		public string LastEditorUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel LastEditorUserIdNavigation { get; private set; }

		public void SetLastEditorUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.LastEditorUserIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? OwnerUserId { get; private set; }

		[JsonProperty]
		public string OwnerUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel OwnerUserIdNavigation { get; private set; }

		public void SetOwnerUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.OwnerUserIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? ParentId { get; private set; }

		[JsonProperty]
		public string ParentIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostServerResponseModel ParentIdNavigation { get; private set; }

		public void SetParentIdNavigation(ApiPostServerResponseModel value)
		{
			this.ParentIdNavigation = value;
		}

		[JsonProperty]
		public int PostTypeId { get; private set; }

		[JsonProperty]
		public string PostTypeIdEntity { get; private set; } = RouteConstants.PostTypes;

		[JsonProperty]
		public ApiPostTypeServerResponseModel PostTypeIdNavigation { get; private set; }

		public void SetPostTypeIdNavigation(ApiPostTypeServerResponseModel value)
		{
			this.PostTypeIdNavigation = value;
		}

		[JsonProperty]
		public int Score { get; private set; }

		[Required]
		[JsonProperty]
		public string Tag { get; private set; }

		[Required]
		[JsonProperty]
		public string Title { get; private set; }

		[JsonProperty]
		public int ViewCount { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0e3ed9dd925c65424d27f7b4bc7db6ff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/