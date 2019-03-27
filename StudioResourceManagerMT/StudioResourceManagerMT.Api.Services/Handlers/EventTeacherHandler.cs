using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class EventTeacherCreatedHandler : INotificationHandler<EventTeacherCreatedNotification>
	{
		public async Task Handle(EventTeacherCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventTeacherUpdatedHandler : INotificationHandler<EventTeacherUpdatedNotification>
	{
		public async Task Handle(EventTeacherUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventTeacherDeletedHandler : INotificationHandler<EventTeacherDeletedNotification>
	{
		public async Task Handle(EventTeacherDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventTeacherCreatedNotification : INotification
	{
		public ApiEventTeacherServerResponseModel Record { get; private set; }

		public EventTeacherCreatedNotification(ApiEventTeacherServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventTeacherUpdatedNotification : INotification
	{
		public ApiEventTeacherServerResponseModel Record { get; private set; }

		public EventTeacherUpdatedNotification(ApiEventTeacherServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventTeacherDeletedNotification : INotification
	{
		public int EventId { get; private set; }

		public EventTeacherDeletedNotification(int eventId)
		{
			this.EventId = eventId;
		}
	}
}

/*<Codenesium>
    <Hash>9c31553c2d9220068db2a1b9414b69cf</Hash>
</Codenesium>*/