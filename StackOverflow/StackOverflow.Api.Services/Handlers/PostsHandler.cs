using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostsCreatedHandler : INotificationHandler<PostsCreatedNotification>
	{
		public async Task Handle(PostsCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostsUpdatedHandler : INotificationHandler<PostsUpdatedNotification>
	{
		public async Task Handle(PostsUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostsDeletedHandler : INotificationHandler<PostsDeletedNotification>
	{
		public async Task Handle(PostsDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PostsCreatedNotification : INotification
	{
		public ApiPostsServerResponseModel Record { get; private set; }

		public PostsCreatedNotification(ApiPostsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostsUpdatedNotification : INotification
	{
		public ApiPostsServerResponseModel Record { get; private set; }

		public PostsUpdatedNotification(ApiPostsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PostsDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PostsDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>890b8280bd4a2e4cce43ece2eb1bc331</Hash>
</Codenesium>*/