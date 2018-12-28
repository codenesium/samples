using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class StudioCreatedHandler : INotificationHandler<StudioCreatedNotification>
	{
		public async Task Handle(StudioCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioUpdatedHandler : INotificationHandler<StudioUpdatedNotification>
	{
		public async Task Handle(StudioUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioDeletedHandler : INotificationHandler<StudioDeletedNotification>
	{
		public async Task Handle(StudioDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioCreatedNotification : INotification
	{
		public BOStudio Record { get; private set; }

		public StudioCreatedNotification(BOStudio record)
		{
			this.Record = record;
		}
	}

	public class StudioUpdatedNotification : INotification
	{
		public BOStudio Record { get; private set; }

		public StudioUpdatedNotification(BOStudio record)
		{
			this.Record = record;
		}
	}

	public class StudioDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public StudioDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>176b5527d0bcae91e1f33c502b444f05</Hash>
</Codenesium>*/