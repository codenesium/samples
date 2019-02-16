using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiQuoteTweetClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int quoteTweetId,
			string content,
			DateTime date,
			int retweeterUserId,
			int sourceTweetId,
			TimeSpan time)
		{
			this.QuoteTweetId = quoteTweetId;
			this.Content = content;
			this.Date = date;
			this.RetweeterUserId = retweeterUserId;
			this.SourceTweetId = sourceTweetId;
			this.Time = time;

			this.RetweeterUserIdEntity = nameof(ApiResponse.Users);

			this.SourceTweetIdEntity = nameof(ApiResponse.Tweets);
		}

		[JsonProperty]
		public ApiUserClientResponseModel RetweeterUserIdNavigation { get; private set; }

		public void SetRetweeterUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.RetweeterUserIdNavigation = value;
		}

		[JsonProperty]
		public ApiTweetClientResponseModel SourceTweetIdNavigation { get; private set; }

		public void SetSourceTweetIdNavigation(ApiTweetClientResponseModel value)
		{
			this.SourceTweetIdNavigation = value;
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int QuoteTweetId { get; private set; }

		[JsonProperty]
		public int RetweeterUserId { get; private set; }

		[JsonProperty]
		public string RetweeterUserIdEntity { get; set; }

		[JsonProperty]
		public int SourceTweetId { get; private set; }

		[JsonProperty]
		public string SourceTweetIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>65e3f335cc494ee651cfe7f07bcc22db</Hash>
</Codenesium>*/