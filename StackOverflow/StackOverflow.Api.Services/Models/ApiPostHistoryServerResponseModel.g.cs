using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostHistoryServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string Comment { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostHistoryTypeId { get; private set; }

		[JsonProperty]
		public string PostHistoryTypeIdEntity { get; private set; } = RouteConstants.PostHistoryTypes;

		[JsonProperty]
		public ApiPostHistoryTypesServerResponseModel PostHistoryTypeIdNavigation { get; private set; }

		public void SetPostHistoryTypeIdNavigation(ApiPostHistoryTypesServerResponseModel value)
		{
			this.PostHistoryTypeIdNavigation = value;
		}

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string PostIdEntity { get; private set; } = RouteConstants.Posts;

		[JsonProperty]
		public ApiPostsServerResponseModel PostIdNavigation { get; private set; }

		public void SetPostIdNavigation(ApiPostsServerResponseModel value)
		{
			this.PostIdNavigation = value;
		}

		[JsonProperty]
		public string RevisionGUID { get; private set; }

		[Required]
		[JsonProperty]
		public string Text { get; private set; }

		[Required]
		[JsonProperty]
		public string UserDisplayName { get; private set; }

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUsersServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUsersServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>c5a606c6eb601b7b8dd46b4a09fcbd2e</Hash>
</Codenesium>*/