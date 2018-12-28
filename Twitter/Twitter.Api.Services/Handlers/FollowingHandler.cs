using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class FollowingCreatedHandler : INotificationHandler<FollowingCreatedNotification>
	{
		public async Task Handle(FollowingCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowingUpdatedHandler : INotificationHandler<FollowingUpdatedNotification>
	{
		public async Task Handle(FollowingUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowingDeletedHandler : INotificationHandler<FollowingDeletedNotification>
	{
		public async Task Handle(FollowingDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowingCreatedNotification : INotification
	{
		public ApiFollowingServerResponseModel Record { get; private set; }

		public FollowingCreatedNotification(ApiFollowingServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FollowingUpdatedNotification : INotification
	{
		public ApiFollowingServerResponseModel Record { get; private set; }

		public FollowingUpdatedNotification(ApiFollowingServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FollowingDeletedNotification : INotification
	{
		public int UserId { get; private set; }

		public FollowingDeletedNotification(int userId)
		{
			this.UserId = userId;
		}
	}
}

/*<Codenesium>
    <Hash>4596f2525fd392b714f362b9203c33e5</Hash>
</Codenesium>*/