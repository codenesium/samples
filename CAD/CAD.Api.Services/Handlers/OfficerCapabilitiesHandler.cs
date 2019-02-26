using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OfficerCapabilitiesCreatedHandler : INotificationHandler<OfficerCapabilitiesCreatedNotification>
	{
		public async Task Handle(OfficerCapabilitiesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilitiesUpdatedHandler : INotificationHandler<OfficerCapabilitiesUpdatedNotification>
	{
		public async Task Handle(OfficerCapabilitiesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilitiesDeletedHandler : INotificationHandler<OfficerCapabilitiesDeletedNotification>
	{
		public async Task Handle(OfficerCapabilitiesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerCapabilitiesCreatedNotification : INotification
	{
		public ApiOfficerCapabilitiesServerResponseModel Record { get; private set; }

		public OfficerCapabilitiesCreatedNotification(ApiOfficerCapabilitiesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerCapabilitiesUpdatedNotification : INotification
	{
		public ApiOfficerCapabilitiesServerResponseModel Record { get; private set; }

		public OfficerCapabilitiesUpdatedNotification(ApiOfficerCapabilitiesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerCapabilitiesDeletedNotification : INotification
	{
		public int CapabilityId { get; private set; }

		public OfficerCapabilitiesDeletedNotification(int capabilityId)
		{
			this.CapabilityId = capabilityId;
		}
	}
}

/*<Codenesium>
    <Hash>82e26c77608a42878b6b2c03e098041e</Hash>
</Codenesium>*/