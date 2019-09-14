using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostHistoryClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostHistoryClientRequestModel()
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

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int PostHistoryTypeId { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public string RevisionGUID { get; private set; } = default(string);

		[JsonProperty]
		public string Text { get; private set; } = default(string);

		[JsonProperty]
		public string UserDisplayName { get; private set; } = default(string);

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a2406eb24284b7fd706ae88ced092e00</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/