using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class VenueCreatedHandler : INotificationHandler<VenueCreatedNotification>
	{
		public async Task Handle(VenueCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VenueUpdatedHandler : INotificationHandler<VenueUpdatedNotification>
	{
		public async Task Handle(VenueUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VenueDeletedHandler : INotificationHandler<VenueDeletedNotification>
	{
		public async Task Handle(VenueDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VenueCreatedNotification : INotification
	{
		public ApiVenueServerResponseModel Record { get; private set; }

		public VenueCreatedNotification(ApiVenueServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VenueUpdatedNotification : INotification
	{
		public ApiVenueServerResponseModel Record { get; private set; }

		public VenueUpdatedNotification(ApiVenueServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VenueDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VenueDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>9a1fa144a9679685577d54a2b8ee445b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/