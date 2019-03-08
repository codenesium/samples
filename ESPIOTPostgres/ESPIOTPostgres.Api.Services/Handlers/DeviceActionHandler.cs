using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public class DeviceActionCreatedHandler : INotificationHandler<DeviceActionCreatedNotification>
	{
		public async Task Handle(DeviceActionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceActionUpdatedHandler : INotificationHandler<DeviceActionUpdatedNotification>
	{
		public async Task Handle(DeviceActionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceActionDeletedHandler : INotificationHandler<DeviceActionDeletedNotification>
	{
		public async Task Handle(DeviceActionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceActionCreatedNotification : INotification
	{
		public ApiDeviceActionServerResponseModel Record { get; private set; }

		public DeviceActionCreatedNotification(ApiDeviceActionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DeviceActionUpdatedNotification : INotification
	{
		public ApiDeviceActionServerResponseModel Record { get; private set; }

		public DeviceActionUpdatedNotification(ApiDeviceActionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DeviceActionDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public DeviceActionDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>25a366dfe7dae1f2033bbe0424e3589b</Hash>
</Codenesium>*/