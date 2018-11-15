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
		public int PostId { get; private set; }

		[JsonProperty]
		public string RevisionGUID { get; private set; }

		[JsonProperty]
		public string Text { get; private set; }

		[JsonProperty]
		public string UserDisplayName { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>92305d383698cb5b47083c9479216178</Hash>
</Codenesium>*/