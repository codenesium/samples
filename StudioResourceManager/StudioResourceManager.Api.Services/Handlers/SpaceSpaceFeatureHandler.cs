using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
		public int Id { get; private set; }

		public SpaceSpaceFeatureDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>495fb929ad68a3d7f152b8b6a8a7c6f7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/