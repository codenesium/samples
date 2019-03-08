using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class CommentsCreatedHandler : INotificationHandler<CommentsCreatedNotification>
	{
		public async Task Handle(CommentsCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentsUpdatedHandler : INotificationHandler<CommentsUpdatedNotification>
	{
		public async Task Handle(CommentsUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentsDeletedHandler : INotificationHandler<CommentsDeletedNotification>
	{
		public async Task Handle(CommentsDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CommentsCreatedNotification : INotification
	{
		public ApiCommentsServerResponseModel Record { get; private set; }

		public CommentsCreatedNotification(ApiCommentsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CommentsUpdatedNotification : INotification
	{
		public ApiCommentsServerResponseModel Record { get; private set; }

		public CommentsUpdatedNotification(ApiCommentsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CommentsDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CommentsDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>4e88182a53fb59fb3ad06ce59ffb8da2</Hash>
</Codenesium>*/