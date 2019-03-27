using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OffCapabilityCreatedHandler : INotificationHandler<OffCapabilityCreatedNotification>
	{
		public async Task Handle(OffCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OffCapabilityUpdatedHandler : INotificationHandler<OffCapabilityUpdatedNotification>
	{
		public async Task Handle(OffCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OffCapabilityDeletedHandler : INotificationHandler<OffCapabilityDeletedNotification>
	{
		public async Task Handle(OffCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OffCapabilityCreatedNotification : INotification
	{
		public ApiOffCapabilityServerResponseModel Record { get; private set; }

		public OffCapabilityCreatedNotification(ApiOffCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OffCapabilityUpdatedNotification : INotification
	{
		public ApiOffCapabilityServerResponseModel Record { get; private set; }

		public OffCapabilityUpdatedNotification(ApiOffCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OffCapabilityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public OffCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d55ed09a4c8429b47575ab3f7fa26953</Hash>
</Codenesium>*/