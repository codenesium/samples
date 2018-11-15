using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiReplyClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int replyId,
			string content,
			DateTime date,
			int replierUserId,
			TimeSpan time)
		{
			this.ReplyId = replyId;
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.Time = time;

			this.ReplierUserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int ReplierUserId { get; private set; }

		[JsonProperty]
		public string ReplierUserIdEntity { get; set; }

		[JsonProperty]
		public int ReplyId { get; private set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c520c827a8044404cb33c9c1e42ffb26</Hash>
</Codenesium>*/