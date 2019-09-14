using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
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
		public int UserId { get; private set; }

		public UserDeletedNotification(int userId)
		{
			this.UserId = userId;
		}
	}
}

/*<Codenesium>
    <Hash>9d61e7a5ae13002c3f657a3163e73db4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/