using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class EventStatusCreatedHandler : INotificationHandler<EventStatusCreatedNotification>
	{
		public async Task Handle(EventStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatusUpdatedHandler : INotificationHandler<EventStatusUpdatedNotification>
	{
		public async Task Handle(EventStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatusDeletedHandler : INotificationHandler<EventStatusDeletedNotification>
	{
		public async Task Handle(EventStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatusCreatedNotification : INotification
	{
		public ApiEventStatusServerResponseModel Record { get; private set; }

		public EventStatusCreatedNotification(ApiEventStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStatusUpdatedNotification : INotification
	{
		public ApiEventStatusServerResponseModel Record { get; private set; }

		public EventStatusUpdatedNotification(ApiEventStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public EventStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>45cdcc7f459130433003829f51088aa2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/