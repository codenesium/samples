using MediatR;
using System;
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
		public ApiSpaceServerResponseModel Record { get; private set; }

		public SpaceCreatedNotification(ApiSpaceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpaceUpdatedNotification : INotification
	{
		public ApiSpaceServerResponseModel Record { get; private set; }

		public SpaceUpdatedNotification(ApiSpaceServerResponseModel record)
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
    <Hash>254e5bc1646bbf10a91f25d0e1823696</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/