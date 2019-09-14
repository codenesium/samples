using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class UserCreatedHandler : INotificationHandler<UserCreatedNotification>
	{
		public async Task Handle(UserCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UserUpdatedHandler : INotificationHandler<UserUpdatedNotification>
	{
		public async Task Handle(UserUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UserDeletedHandler : INotificationHandler<UserDeletedNotification>
	{
		public async Task Handle(UserDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UserCreatedNotification : INotification
	{
		public ApiUserServerResponseModel Record { get; private set; }

		public UserCreatedNotification(ApiUserServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UserUpdatedNotification : INotification
	{
		public ApiUserServerResponseModel Record { get; private set; }

		public UserUpdatedNotification(ApiUserServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UserDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public UserDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>41d9bdc8765e9291002161965daf584a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/