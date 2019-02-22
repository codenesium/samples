using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleRefCapabilityCreatedHandler : INotificationHandler<VehicleRefCapabilityCreatedNotification>
	{
		public async Task Handle(VehicleRefCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleRefCapabilityUpdatedHandler : INotificationHandler<VehicleRefCapabilityUpdatedNotification>
	{
		public async Task Handle(VehicleRefCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleRefCapabilityDeletedHandler : INotificationHandler<VehicleRefCapabilityDeletedNotification>
	{
		public async Task Handle(VehicleRefCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleRefCapabilityCreatedNotification : INotification
	{
		public ApiVehicleRefCapabilityServerResponseModel Record { get; private set; }

		public VehicleRefCapabilityCreatedNotification(ApiVehicleRefCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleRefCapabilityUpdatedNotification : INotification
	{
		public ApiVehicleRefCapabilityServerResponseModel Record { get; private set; }

		public VehicleRefCapabilityUpdatedNotification(ApiVehicleRefCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleRefCapabilityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VehicleRefCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>bf6469f31ae7e72ca5b5bc73363da521</Hash>
</Codenesium>*/