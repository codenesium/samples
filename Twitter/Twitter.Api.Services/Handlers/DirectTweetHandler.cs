using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class DirectTweetCreatedHandler : INotificationHandler<DirectTweetCreatedNotification>
	{
		public async Task Handle(DirectTweetCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DirectTweetUpdatedHandler : INotificationHandler<DirectTweetUpdatedNotification>
	{
		public async Task Handle(DirectTweetUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DirectTweetDeletedHandler : INotificationHandler<DirectTweetDeletedNotification>
	{
		public async Task Handle(DirectTweetDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DirectTweetCreatedNotification : INotification
	{
		public ApiDirectTweetServerResponseModel Record { get; private set; }

		public DirectTweetCreatedNotification(ApiDirectTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DirectTweetUpdatedNotification : INotification
	{
		public ApiDirectTweetServerResponseModel Record { get; private set; }

		public DirectTweetUpdatedNotification(ApiDirectTweetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DirectTweetDeletedNotification : INotification
	{
		public int TweetId { get; private set; }

		public DirectTweetDeletedNotification(int tweetId)
		{
			this.TweetId = tweetId;
		}
	}
}

/*<Codenesium>
    <Hash>896a27796a1242eb064b19f131d9cbdb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/