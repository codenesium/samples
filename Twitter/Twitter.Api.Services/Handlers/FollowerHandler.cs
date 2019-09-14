using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class FollowerCreatedHandler : INotificationHandler<FollowerCreatedNotification>
	{
		public async Task Handle(FollowerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowerUpdatedHandler : INotificationHandler<FollowerUpdatedNotification>
	{
		public async Task Handle(FollowerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowerDeletedHandler : INotificationHandler<FollowerDeletedNotification>
	{
		public async Task Handle(FollowerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FollowerCreatedNotification : INotification
	{
		public ApiFollowerServerResponseModel Record { get; private set; }

		public FollowerCreatedNotification(ApiFollowerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FollowerUpdatedNotification : INotification
	{
		public ApiFollowerServerResponseModel Record { get; private set; }

		public FollowerUpdatedNotification(ApiFollowerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FollowerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public FollowerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>37a4fe723fc168bdbfd6b8a997e3c50f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/