using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class DeviceCreatedHandler : INotificationHandler<DeviceCreatedNotification>
	{
		public async Task Handle(DeviceCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceUpdatedHandler : INotificationHandler<DeviceUpdatedNotification>
	{
		public async Task Handle(DeviceUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceDeletedHandler : INotificationHandler<DeviceDeletedNotification>
	{
		public async Task Handle(DeviceDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DeviceCreatedNotification : INotification
	{
		public ApiDeviceServerResponseModel Record { get; private set; }

		public DeviceCreatedNotification(ApiDeviceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DeviceUpdatedNotification : INotification
	{
		public ApiDeviceServerResponseModel Record { get; private set; }

		public DeviceUpdatedNotification(ApiDeviceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DeviceDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public DeviceDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>ac34dcc6acd6be7584b022ff7b426ad4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/