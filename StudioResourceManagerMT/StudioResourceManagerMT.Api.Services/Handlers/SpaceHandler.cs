using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class SpaceCreatedHandler : INotificationHandler<SpaceCreatedNotification>
	{
		public async Task Handle(SpaceCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceUpdatedHandler : INotificationHandler<SpaceUpdatedNotification>
	{
		public async Task Handle(SpaceUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceDeletedHandler : INotificationHandler<SpaceDeletedNotification>
	{
		public async Task Handle(SpaceDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceCreatedNotification : INotification
	{
		public BOSpace Record { get; private set; }

		public SpaceCreatedNotification(BOSpace record)
		{
			this.Record = record;
		}
	}

	public class SpaceUpdatedNotification : INotification
	{
		public BOSpace Record { get; private set; }

		public SpaceUpdatedNotification(BOSpace record)
		{
			this.Record = record;
		}
	}

	public class SpaceDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SpaceDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>4b2f1e0e798ecbc34657f71ca75f8e36</Hash>
</Codenesium>*/