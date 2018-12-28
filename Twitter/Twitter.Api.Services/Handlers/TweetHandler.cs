using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class TweetCreatedHandler : INotificationHandler<TweetCreatedNotification>
	{
		public async Task Handle(TweetCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TweetUpdatedHandler : INotificationHandler<TweetUpdatedNotification>
	{
		public async Task Handle(TweetUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TweetDeletedHandler : INotificationHandler<TweetDeletedNotification>
	{
		public async Task Handle(TweetDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TweetCreatedNotification : INotification
	{
		public ApiTweetServerResponseModel Record { get; private set; }

		public TweetCreatedNotification(ApiTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TweetUpdatedNotification : INotification
	{
		public ApiTweetServerResponseModel Record { get; private set; }

		public TweetUpdatedNotification(ApiTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TweetDeletedNotification : INotification
	{
		public int TweetId { get; private set; }

		public TweetDeletedNotification(int tweetId)
		{
			this.TweetId = tweetId;
		}
	}
}

/*<Codenesium>
    <Hash>c2f4525c4105120755ec10bb924358f0</Hash>
</Codenesium>*/