using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostHistoryCreatedHandler : INotificationHandler<PostHistoryCreatedNotification>
	{
		public async Task Handle(PostHistoryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryUpdatedHandler : INotificationHandler<PostHistoryUpdatedNotification>
	{
		public async Task Handle(PostHistoryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryDeletedHandler : INotificationHandler<PostHistoryDeletedNotification>
	{
		public async Task Handle(PostHistoryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryCreatedNotification : INotification
	{
		public ApiPostHistoryServerResponseModel Record { get; private set; }

		public PostHistoryCreatedNotification(ApiPostHistoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryUpdatedNotification : INotification
	{
		public ApiPostHistoryServerResponseModel Record { get; private set; }

		public PostHistoryUpdatedNotification(ApiPostHistoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostHistoryDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>a25d47261b1700b97b286a2997814909</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/