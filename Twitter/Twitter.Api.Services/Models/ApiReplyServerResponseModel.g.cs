using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiReplyServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>7389dce346ae441181597d783c67f79e</Hash>
</Codenesium>*/