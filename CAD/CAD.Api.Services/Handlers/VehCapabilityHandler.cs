using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehCapabilityCreatedHandler : INotificationHandler<VehCapabilityCreatedNotification>
	{
		public async Task Handle(VehCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehCapabilityUpdatedHandler : INotificationHandler<VehCapabilityUpdatedNotification>
	{
		public async Task Handle(VehCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehCapabilityDeletedHandler : INotificationHandler<VehCapabilityDeletedNotification>
	{
		public async Task Handle(VehCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VehCapabilityCreatedNotification : INotification
	{
		public ApiVehCapabilityServerResponseModel Record { get; private set; }

		public VehCapabilityCreatedNotification(ApiVehCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehCapabilityUpdatedNotification : INotification
	{
		public ApiVehCapabilityServerResponseModel Record { get; private set; }

		public VehCapabilityUpdatedNotification(ApiVehCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VehCapabilityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VehCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>dffb54da8cc2a16401e179273c683e2e</Hash>
</Codenesium>*/