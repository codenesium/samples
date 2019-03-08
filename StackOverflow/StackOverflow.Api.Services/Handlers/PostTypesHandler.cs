using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostTypesCreatedHandler : INotificationHandler<PostTypesCreatedNotification>
	{
		public async Task Handle(PostTypesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypesUpdatedHandler : INotificationHandler<PostTypesUpdatedNotification>
	{
		public async Task Handle(PostTypesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypesDeletedHandler : INotificationHandler<PostTypesDeletedNotification>
	{
		public async Task Handle(PostTypesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostTypesCreatedNotification : INotification
	{
		public ApiPostTypesServerResponseModel Record { get; private set; }

		public PostTypesCreatedNotification(ApiPostTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostTypesUpdatedNotification : INotification
	{
		public ApiPostTypesServerResponseModel Record { get; private set; }

		public PostTypesUpdatedNotification(ApiPostTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostTypesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostTypesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d8b184f40378483165fba27a65a71952</Hash>
</Codenesium>*/