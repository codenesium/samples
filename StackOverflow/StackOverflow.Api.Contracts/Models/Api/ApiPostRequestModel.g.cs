using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiPostRequestModel : AbstractApiRequestModel
	{
		public ApiPostRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public int? AcceptedAnswerId { get; private set; }

		[JsonProperty]
		public int? AnswerCount { get; private set; }

		[Required]
		[JsonProperty]
		public string Body { get; private set; }

		[JsonProperty]
		public DateTime? ClosedDate { get; private set; }

		[JsonProperty]
		public int? CommentCount { get; private set; }

		[JsonProperty]
		public DateTime? CommunityOwnedDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int? FavoriteCount { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime LastActivityDate { get; private set; }

		[JsonProperty]
		public DateTime? LastEditDate { get; private set; }

		[JsonProperty]
		public string LastEditorDisplayName { get; private set; }

		[JsonProperty]
		public int? LastEditorUserId { get; private set; }

		[JsonProperty]
		public int? OwnerUserId { get; private set; }

		[JsonProperty]
		public int? ParentId { get; private set; }

		[Required]
		[JsonProperty]
		public int PostTypeId { get; private set; }

		[Required]
		[JsonProperty]
		public int Score { get; private set; }

		[JsonProperty]
		public string Tag { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }

		[Required]
		[JsonProperty]
		public int ViewCount { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9c0379cbab4684ef5428f9f096094537</Hash>
</Codenesium>*/