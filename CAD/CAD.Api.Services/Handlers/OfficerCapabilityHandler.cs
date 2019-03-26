using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OfficerCapabilityCreatedHandler : INotificationHandler<OfficerCapabilityCreatedNotification>
	{
		public async Task Handle(OfficerCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilityUpdatedHandler : INotificationHandler<OfficerCapabilityUpdatedNotification>
	{
		public async Task Handle(OfficerCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilityDeletedHandler : INotificationHandler<OfficerCapabilityDeletedNotification>
	{
		public async Task Handle(OfficerCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilityCreatedNotification : INotification
	{
		public ApiOfficerCapabilityServerResponseModel Record { get; private set; }

		public OfficerCapabilityCreatedNotification(ApiOfficerCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerCapabilityUpdatedNotification : INotification
	{
		public ApiOfficerCapabilityServerResponseModel Record { get; private set; }

		public OfficerCapabilityUpdatedNotification(ApiOfficerCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerCapabilityDeletedNotification : INotification
	{
		public int CapabilityId { get; private set; }

		public OfficerCapabilityDeletedNotification(int capabilityId)
		{
			this.CapabilityId = capabilityId;
		}
	}
}

/*<Codenesium>
    <Hash>8c8a415bfa82d2f011d122b62e632434</Hash>
</Codenesium>*/