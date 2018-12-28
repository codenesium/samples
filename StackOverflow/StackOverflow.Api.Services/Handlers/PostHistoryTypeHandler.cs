using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostHistoryTypeCreatedHandler : INotificationHandler<PostHistoryTypeCreatedNotification>
	{
		public async Task Handle(PostHistoryTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypeUpdatedHandler : INotificationHandler<PostHistoryTypeUpdatedNotification>
	{
		public async Task Handle(PostHistoryTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypeDeletedHandler : INotificationHandler<PostHistoryTypeDeletedNotification>
	{
		public async Task Handle(PostHistoryTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypeCreatedNotification : INotification
	{
		public ApiPostHistoryTypeServerResponseModel Record { get; private set; }

		public PostHistoryTypeCreatedNotification(ApiPostHistoryTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryTypeUpdatedNotification : INotification
	{
		public ApiPostHistoryTypeServerResponseModel Record { get; private set; }

		public PostHistoryTypeUpdatedNotification(ApiPostHistoryTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostHistoryTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>5b989db15acd6a2306fe61dd731d55dd</Hash>
</Codenesium>*/