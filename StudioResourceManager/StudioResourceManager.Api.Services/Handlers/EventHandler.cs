using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>7e9d31f5d46f381c1917e1053398585e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/