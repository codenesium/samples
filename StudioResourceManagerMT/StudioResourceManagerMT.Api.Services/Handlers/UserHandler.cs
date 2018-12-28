using MediatR;
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
		public BOUser Record { get; private set; }

		public UserCreatedNotification(BOUser record)
		{
			this.Record = record;
		}
	}

	public class UserUpdatedNotification : INotification
	{
		public BOUser Record { get; private set; }

		public UserUpdatedNotification(BOUser record)
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
    <Hash>456d03f917572d5695941df39a72de70</Hash>
</Codenesium>*/