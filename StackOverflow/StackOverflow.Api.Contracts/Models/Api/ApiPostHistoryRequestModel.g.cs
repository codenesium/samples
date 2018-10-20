using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiPostHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiPostHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string comment,
			DateTime creationDate,
			int postHistoryTypeId,
			int postId,
			string revisionGUID,
			string text,
			string userDisplayName,
			int? userId)
		{
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
		public string Comment { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int PostHistoryTypeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string RevisionGUID { get; private set; } = default(string);

		[JsonProperty]
		public string Text { get; private set; } = default(string);

		[JsonProperty]
		public string UserDisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>d3a9f4d6f63af2fbbe15798e6e13ba2f</Hash>
</Codenesium>*/