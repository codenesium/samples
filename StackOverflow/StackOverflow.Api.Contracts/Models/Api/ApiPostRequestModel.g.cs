using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int? AcceptedAnswerId { get; private set; } = default(int);

		[JsonProperty]
		public int? AnswerCount { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Body { get; private set; } = default(string);

		[JsonProperty]
		public DateTime? ClosedDate { get; private set; } = null;

		[JsonProperty]
		public int? CommentCount { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? CommunityOwnedDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int? FavoriteCount { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime LastActivityDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime? LastEditDate { get; private set; } = null;

		[JsonProperty]
		public string LastEditorDisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int? LastEditorUserId { get; private set; } = default(int);

		[JsonProperty]
		public int? OwnerUserId { get; private set; } = default(int);

		[JsonProperty]
		public int? ParentId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PostTypeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int Score { get; private set; } = default(int);

		[JsonProperty]
		public string Tag { get; private set; } = default(string);

		[JsonProperty]
		public string Title { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ViewCount { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>631c89611090814c2cb71a214dc3ff20</Hash>
</Codenesium>*/