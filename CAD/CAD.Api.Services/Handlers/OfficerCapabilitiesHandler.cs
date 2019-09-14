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
		public int Id { get; private set; }

		public OfficerCapabilitiesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>affd30e35553b7a28a84569eb3b0c3a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/