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
		public int Id { get; private set; }

		public VehicleCapabilitiesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>b3856ab7261f3b60dc82070d3e1d2859</Hash>
</Codenesium>*/