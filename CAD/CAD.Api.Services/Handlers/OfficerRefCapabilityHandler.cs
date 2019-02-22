using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OfficerRefCapabilityCreatedHandler : INotificationHandler<OfficerRefCapabilityCreatedNotification>
	{
		public async Task Handle(OfficerRefCapabilityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerRefCapabilityUpdatedHandler : INotificationHandler<OfficerRefCapabilityUpdatedNotification>
	{
		public async Task Handle(OfficerRefCapabilityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerRefCapabilityDeletedHandler : INotificationHandler<OfficerRefCapabilityDeletedNotification>
	{
		public async Task Handle(OfficerRefCapabilityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OfficerRefCapabilityCreatedNotification : INotification
	{
		public ApiOfficerRefCapabilityServerResponseModel Record { get; private set; }

		public OfficerRefCapabilityCreatedNotification(ApiOfficerRefCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerRefCapabilityUpdatedNotification : INotification
	{
		public ApiOfficerRefCapabilityServerResponseModel Record { get; private set; }

		public OfficerRefCapabilityUpdatedNotification(ApiOfficerRefCapabilityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OfficerRefCapabilityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public OfficerRefCapabilityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>453e43db157a23e4a58fd348d9b84797</Hash>
</Codenesium>*/