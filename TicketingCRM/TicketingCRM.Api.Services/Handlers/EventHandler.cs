using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class EventCreatedHandler : INotificationHandler<EventCreatedNotification>
	{
		public async Task Handle(EventCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventUpdatedHandler : INotificationHandler<EventUpdatedNotification>
	{
		public async Task Handle(EventUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventDeletedHandler : INotificationHandler<EventDeletedNotification>
	{
		public async Task Handle(EventDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventCreatedNotification : INotification
	{
		public ApiEventServerResponseModel Record { get; private set; }

		public EventCreatedNotification(ApiEventServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventUpdatedNotification : INotification
	{
		public ApiEventServerResponseModel Record { get; private set; }

		public EventUpdatedNotification(ApiEventServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public EventDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>a3cd03b3e0eae53f25fc3ea358de27e6</Hash>
</Codenesium>*/