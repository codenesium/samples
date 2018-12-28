using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>4f0ff708c9580551212be3ae8c5cc778</Hash>
</Codenesium>*/