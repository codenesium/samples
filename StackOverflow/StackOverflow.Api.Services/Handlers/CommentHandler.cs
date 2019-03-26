using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class CommentCreatedHandler : INotificationHandler<CommentCreatedNotification>
	{
		public async Task Handle(CommentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentUpdatedHandler : INotificationHandler<CommentUpdatedNotification>
	{
		public async Task Handle(CommentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentDeletedHandler : INotificationHandler<CommentDeletedNotification>
	{
		public async Task Handle(CommentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentCreatedNotification : INotification
	{
		public ApiCommentServerResponseModel Record { get; private set; }

		public CommentCreatedNotification(ApiCommentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CommentUpdatedNotification : INotification
	{
		public ApiCommentServerResponseModel Record { get; private set; }

		public CommentUpdatedNotification(ApiCommentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CommentDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CommentDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>3a1378901bf2c3489f0fb0d64a0ca4da</Hash>
</Codenesium>*/