using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class UsersCreatedHandler : INotificationHandler<UsersCreatedNotification>
	{
		public async Task Handle(UsersCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UsersUpdatedHandler : INotificationHandler<UsersUpdatedNotification>
	{
		public async Task Handle(UsersUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UsersDeletedHandler : INotificationHandler<UsersDeletedNotification>
	{
		public async Task Handle(UsersDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UsersCreatedNotification : INotification
	{
		public ApiUsersServerResponseModel Record { get; private set; }

		public UsersCreatedNotification(ApiUsersServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UsersUpdatedNotification : INotification
	{
		public ApiUsersServerResponseModel Record { get; private set; }

		public UsersUpdatedNotification(ApiUsersServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UsersDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public UsersDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>ec4880096463435ea438810accc88a4a</Hash>
</Codenesium>*/