using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class AdminCreatedHandler : INotificationHandler<AdminCreatedNotification>
	{
		public async Task Handle(AdminCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminUpdatedHandler : INotificationHandler<AdminUpdatedNotification>
	{
		public async Task Handle(AdminUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminDeletedHandler : INotificationHandler<AdminDeletedNotification>
	{
		public async Task Handle(AdminDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminCreatedNotification : INotification
	{
		public BOAdmin Record { get; private set; }

		public AdminCreatedNotification(BOAdmin record)
		{
			this.Record = record;
		}
	}

	public class AdminUpdatedNotification : INotification
	{
		public BOAdmin Record { get; private set; }

		public AdminUpdatedNotification(BOAdmin record)
		{
			this.Record = record;
		}
	}

	public class AdminDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public AdminDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1d647c504d817990da4795dff3256e20</Hash>
</Codenesium>*/