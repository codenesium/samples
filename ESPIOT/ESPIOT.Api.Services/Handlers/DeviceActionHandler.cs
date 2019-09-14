using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
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
    <Hash>63403fe58812ff6359b7ca8c16503a8f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/