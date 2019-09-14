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
		public ApiUserClientResponseModel ReplierUserIdNavigation { get; private set; }

		public void SetReplierUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.ReplierUserIdNavigation = value;
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
    <Hash>99093dd54cb1712dbe9124bd9c368b8e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/