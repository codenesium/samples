using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class SpaceSpaceFeatureCreatedHandler : INotificationHandler<SpaceSpaceFeatureCreatedNotification>
	{
		public async Task Handle(SpaceSpaceFeatureCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceSpaceFeatureUpdatedHandler : INotificationHandler<SpaceSpaceFeatureUpdatedNotification>
	{
		public async Task Handle(SpaceSpaceFeatureUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceSpaceFeatureDeletedHandler : INotificationHandler<SpaceSpaceFeatureDeletedNotification>
	{
		public async Task Handle(SpaceSpaceFeatureDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpaceSpaceFeatureCreatedNotification : INotification
	{
		public ApiSpaceSpaceFeatureServerResponseModel Record { get; private set; }

		public SpaceSpaceFeatureCreatedNotification(ApiSpaceSpaceFeatureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpaceSpaceFeatureUpdatedNotification : INotification
	{
		public ApiSpaceSpaceFeatureServerResponseModel Record { get; private set; }

		public SpaceSpaceFeatureUpdatedNotification(ApiSpaceSpaceFeatureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpaceSpaceFeatureDeletedNotification : INotification
	{
		public int SpaceId { get; private set; }

		public SpaceSpaceFeatureDeletedNotification(int spaceId)
		{
			this.SpaceId = spaceId;
		}
	}
}

/*<Codenesium>
    <Hash>8171bdcc4400858377bf079d10c52aba</Hash>
</Codenesium>*/