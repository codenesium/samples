using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleOfficerCreatedHandler : INotificationHandler<VehicleOfficerCreatedNotification>
	{
		public async Task Handle(VehicleOfficerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleOfficerUpdatedHandler : INotificationHandler<VehicleOfficerUpdatedNotification>
	{
		public async Task Handle(VehicleOfficerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleOfficerDeletedHandler : INotificationHandler<VehicleOfficerDeletedNotification>
	{
		public async Task Handle(VehicleOfficerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehicleOfficerCreatedNotification : INotification
	{
		public ApiVehicleOfficerServerResponseModel Record { get; private set; }

		public VehicleOfficerCreatedNotification(ApiVehicleOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleOfficerUpdatedNotification : INotification
	{
		public ApiVehicleOfficerServerResponseModel Record { get; private set; }

		public VehicleOfficerUpdatedNotification(ApiVehicleOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehicleOfficerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VehicleOfficerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>e9709f51c37c0d39e7bc524ee5626f6e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/