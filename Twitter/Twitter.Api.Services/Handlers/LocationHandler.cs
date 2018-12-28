using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class LocationCreatedHandler : INotificationHandler<LocationCreatedNotification>
	{
		public async Task Handle(LocationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LocationUpdatedHandler : INotificationHandler<LocationUpdatedNotification>
	{
		public async Task Handle(LocationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LocationDeletedHandler : INotificationHandler<LocationDeletedNotification>
	{
		public async Task Handle(LocationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LocationCreatedNotification : INotification
	{
		public ApiLocationServerResponseModel Record { get; private set; }

		public LocationCreatedNotification(ApiLocationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LocationUpdatedNotification : INotification
	{
		public ApiLocationServerResponseModel Record { get; private set; }

		public LocationUpdatedNotification(ApiLocationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LocationDeletedNotification : INotification
	{
		public int LocationId { get; private set; }

		public LocationDeletedNotification(int locationId)
		{
			this.LocationId = locationId;
		}
	}
}

/*<Codenesium>
    <Hash>ca03698ad79976fa6dda98adbeb1a590</Hash>
</Codenesium>*/