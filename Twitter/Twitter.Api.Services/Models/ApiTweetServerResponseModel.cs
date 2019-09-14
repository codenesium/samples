using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiTweetServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int tweetId,
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int userUserId)
		{
			this.TweetId = tweetId;
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.UserUserId = userUserId;
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int LocationId { get; private set; }

		[JsonProperty]
		public string LocationIdEntity { get; private set; } = RouteConstants.Locations;

		[JsonProperty]
		public ApiLocationServerResponseModel LocationIdNavigation { get; private set; }

		public void SetLocationIdNavigation(ApiLocationServerResponseModel value)
		{
			this.LocationIdNavigation = value;
		}

		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[JsonProperty]
		public int TweetId { get; private set; }

		[JsonProperty]
		public int UserUserId { get; private set; }

		[JsonProperty]
		public string UserUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel UserUserIdNavigation { get; private set; }

		public void SetUserUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.UserUserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>fd408156cb1a9f45677423399fa7a6e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/