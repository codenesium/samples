using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleCapabilityCreatedHandler : INotificationHandler<VehicleCapabilityCreatedNotification>
	{
		public async Task Handle(VehicleCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilityUpdatedHandler : INotificationHandler<VehicleCapabilityUpdatedNotification>
	{
		public async Task Handle(VehicleCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilityDeletedHandler : INotificationHandler<VehicleCapabilityDeletedNotification>
	{
		public async Task Handle(VehicleCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilityCreatedNotification : INotification
	{
		public ApiVehicleCapabilityServerResponseModel Record { get; private set; }

		public VehicleCapabilityCreatedNotification(ApiVehicleCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilityUpdatedNotification : INotification
	{
		public ApiVehicleCapabilityServerResponseModel Record { get; private set; }

		public VehicleCapabilityUpdatedNotification(ApiVehicleCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VehicleCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1b2e04780eab45890689e32b30d77872</Hash>
</Codenesium>*/