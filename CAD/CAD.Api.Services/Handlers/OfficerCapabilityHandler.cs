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
		public int Id { get; private set; }

		public OfficerCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1c6f3cd695d44c95b758e458b74fe831</Hash>
</Codenesium>*/