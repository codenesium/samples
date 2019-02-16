using MediatR;
using System;
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
		public ApiSpaceFeatureServerResponseModel Record { get; private set; }

		public SpaceFeatureCreatedNotification(ApiSpaceFeatureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpaceFeatureUpdatedNotification : INotification
	{
		public ApiSpaceFeatureServerResponseModel Record { get; private set; }

		public SpaceFeatureUpdatedNotification(ApiSpaceFeatureServerResponseModel record)
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
    <Hash>11b5051766ad4c796e1117c83957d960</Hash>
</Codenesium>*/