using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>819a7dd020b6d6ceeef11cc5925519cc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/