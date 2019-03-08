using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostHistoryTypesCreatedHandler : INotificationHandler<PostHistoryTypesCreatedNotification>
	{
		public async Task Handle(PostHistoryTypesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypesUpdatedHandler : INotificationHandler<PostHistoryTypesUpdatedNotification>
	{
		public async Task Handle(PostHistoryTypesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypesDeletedHandler : INotificationHandler<PostHistoryTypesDeletedNotification>
	{
		public async Task Handle(PostHistoryTypesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostHistoryTypesCreatedNotification : INotification
	{
		public ApiPostHistoryTypesServerResponseModel Record { get; private set; }

		public PostHistoryTypesCreatedNotification(ApiPostHistoryTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryTypesUpdatedNotification : INotification
	{
		public ApiPostHistoryTypesServerResponseModel Record { get; private set; }

		public PostHistoryTypesUpdatedNotification(ApiPostHistoryTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostHistoryTypesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostHistoryTypesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f4ea6c956e61c6a379cbcf1155edab26</Hash>
</Codenesium>*/