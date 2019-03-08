using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostLinksCreatedHandler : INotificationHandler<PostLinksCreatedNotification>
	{
		public async Task Handle(PostLinksCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinksUpdatedHandler : INotificationHandler<PostLinksUpdatedNotification>
	{
		public async Task Handle(PostLinksUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinksDeletedHandler : INotificationHandler<PostLinksDeletedNotification>
	{
		public async Task Handle(PostLinksDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostLinksCreatedNotification : INotification
	{
		public ApiPostLinksServerResponseModel Record { get; private set; }

		public PostLinksCreatedNotification(ApiPostLinksServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostLinksUpdatedNotification : INotification
	{
		public ApiPostLinksServerResponseModel Record { get; private set; }

		public PostLinksUpdatedNotification(ApiPostLinksServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostLinksDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostLinksDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>3f6b4e3a92eb97ee59764c6638e33eab</Hash>
</Codenesium>*/