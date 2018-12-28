using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class EventStatuCreatedHandler : INotificationHandler<EventStatuCreatedNotification>
	{
		public async Task Handle(EventStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatuUpdatedHandler : INotificationHandler<EventStatuUpdatedNotification>
	{
		public async Task Handle(EventStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatuDeletedHandler : INotificationHandler<EventStatuDeletedNotification>
	{
		public async Task Handle(EventStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStatuCreatedNotification : INotification
	{
		public ApiEventStatuServerResponseModel Record { get; private set; }

		public EventStatuCreatedNotification(ApiEventStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStatuUpdatedNotification : INotification
	{
		public ApiEventStatuServerResponseModel Record { get; private set; }

		public EventStatuUpdatedNotification(ApiEventStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public EventStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>02d86cc3c42dd15d4d1060b9c93550d8</Hash>
</Codenesium>*/