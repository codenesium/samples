using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleCapabilittyCreatedHandler : INotificationHandler<VehicleCapabilittyCreatedNotification>
	{
		public async Task Handle(VehicleCapabilittyCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilittyUpdatedHandler : INotificationHandler<VehicleCapabilittyUpdatedNotification>
	{
		public async Task Handle(VehicleCapabilittyUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilittyDeletedHandler : INotificationHandler<VehicleCapabilittyDeletedNotification>
	{
		public async Task Handle(VehicleCapabilittyDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleCapabilittyCreatedNotification : INotification
	{
		public ApiVehicleCapabilittyServerResponseModel Record { get; private set; }

		public VehicleCapabilittyCreatedNotification(ApiVehicleCapabilittyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilittyUpdatedNotification : INotification
	{
		public ApiVehicleCapabilittyServerResponseModel Record { get; private set; }

		public VehicleCapabilittyUpdatedNotification(ApiVehicleCapabilittyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleCapabilittyDeletedNotification : INotification
	{
		public int VehicleId { get; private set; }

		public VehicleCapabilittyDeletedNotification(int vehicleId)
		{
			this.VehicleId = vehicleId;
		}
	}
}

/*<Codenesium>
    <Hash>d4e03c4e321ffb3e73cfdf68041261f4</Hash>
</Codenesium>*/