using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostClientRequestModel()
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

		[JsonProperty]
		public string Body { get; private set; } = default(string);

		[JsonProperty]
		public DateTime? ClosedDate { get; private set; } = null;

		[JsonProperty]
		public int? CommentCount { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? CommunityOwnedDate { get; private set; } = null;

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int? FavoriteCount { get; private set; } = default(int);

		[JsonProperty]
		public DateTime LastActivityDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime? LastEditDate { get; private set; } = null;

		[JsonProperty]
		public string LastEditorDisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int? LastEditorUserId { get; private set; }

		[JsonProperty]
		public int? OwnerUserId { get; private set; }

		[JsonProperty]
		public int? ParentId { get; private set; }

		[JsonProperty]
		public int PostTypeId { get; private set; }

		[JsonProperty]
		public int Score { get; private set; } = default(int);

		[JsonProperty]
		public string Tag { get; private set; } = default(string);

		[JsonProperty]
		public string Title { get; private set; } = default(string);

		[JsonProperty]
		public int ViewCount { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>f82e7ac974cf0749697dbf917aacd603</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/