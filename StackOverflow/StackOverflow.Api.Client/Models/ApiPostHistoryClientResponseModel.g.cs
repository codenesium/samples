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
		public ApiPostHistoryTypeClientResponseModel PostHistoryTypeIdNavigation { get; private set; }

		public void SetPostHistoryTypeIdNavigation(ApiPostHistoryTypeClientResponseModel value)
		{
			this.PostHistoryTypeIdNavigation = value;
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
    <Hash>7553bea1add5b5ee2c3b8ef1224519d4</Hash>
</Codenesium>*/