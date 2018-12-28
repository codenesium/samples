using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class SpaceFeatureCreatedHandler : INotificationHandler<SpaceFeatureCreatedNotification>
	{
		public async Task Handle(SpaceFeatureCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceFeatureUpdatedHandler : INotificationHandler<SpaceFeatureUpdatedNotification>
	{
		public async Task Handle(SpaceFeatureUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceFeatureDeletedHandler : INotificationHandler<SpaceFeatureDeletedNotification>
	{
		public async Task Handle(SpaceFeatureDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceFeatureCreatedNotification : INotification
	{
		public BOSpaceFeature Record { get; private set; }

		public SpaceFeatureCreatedNotification(BOSpaceFeature record)
		{
			this.Record = record;
		}
	}

	public class SpaceFeatureUpdatedNotification : INotification
	{
		public BOSpaceFeature Record { get; private set; }

		public SpaceFeatureUpdatedNotification(BOSpaceFeature record)
		{
			this.Record = record;
		}
	}

	public class SpaceFeatureDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SpaceFeatureDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>913205bc785ff4aa57c48bfc2d06bafe</Hash>
</Codenesium>*/