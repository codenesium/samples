using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleCapabilitiesCreatedHandler : INotificationHandler<VehicleCapabilitiesCreatedNotification>
	{
		public async Task Handle(VehicleCapabilitiesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilitiesUpdatedHandler : INotificationHandler<VehicleCapabilitiesUpdatedNotification>
	{
		public async Task Handle(VehicleCapabilitiesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilitiesDeletedHandler : INotificationHandler<VehicleCapabilitiesDeletedNotification>
	{
		public async Task Handle(VehicleCapabilitiesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilitiesCreatedNotification : INotification
	{
		public ApiVehicleCapabilitiesServerResponseModel Record { get; private set; }

		public VehicleCapabilitiesCreatedNotification(ApiVehicleCapabilitiesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilitiesUpdatedNotification : INotification
	{
		public ApiVehicleCapabilitiesServerResponseModel Record { get; private set; }

		public VehicleCapabilitiesUpdatedNotification(ApiVehicleCapabilitiesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilitiesDeletedNotification : INotification
	{
		public int VehicleId { get; private set; }

		public VehicleCapabilitiesDeletedNotification(int vehicleId)
		{
			this.VehicleId = vehicleId;
		}
	}
}

/*<Codenesium>
    <Hash>8357bdb10ee6ef5bfa43cd1416150333</Hash>
</Codenesium>*/