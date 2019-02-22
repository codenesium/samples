using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleCreatedHandler : INotificationHandler<VehicleCreatedNotification>
	{
		public async Task Handle(VehicleCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleUpdatedHandler : INotificationHandler<VehicleUpdatedNotification>
	{
		public async Task Handle(VehicleUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleDeletedHandler : INotificationHandler<VehicleDeletedNotification>
	{
		public async Task Handle(VehicleDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCreatedNotification : INotification
	{
		public ApiVehicleServerResponseModel Record { get; private set; }

		public VehicleCreatedNotification(ApiVehicleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleUpdatedNotification : INotification
	{
		public ApiVehicleServerResponseModel Record { get; private set; }

		public VehicleUpdatedNotification(ApiVehicleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VehicleDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d3f5a72168e9e1fc9e9c71fc47cdb551</Hash>
</Codenesium>*/