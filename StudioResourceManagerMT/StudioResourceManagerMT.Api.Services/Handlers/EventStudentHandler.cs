using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class EventStudentCreatedHandler : INotificationHandler<EventStudentCreatedNotification>
	{
		public async Task Handle(EventStudentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStudentUpdatedHandler : INotificationHandler<EventStudentUpdatedNotification>
	{
		public async Task Handle(EventStudentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStudentDeletedHandler : INotificationHandler<EventStudentDeletedNotification>
	{
		public async Task Handle(EventStudentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EventStudentCreatedNotification : INotification
	{
		public ApiEventStudentServerResponseModel Record { get; private set; }

		public EventStudentCreatedNotification(ApiEventStudentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStudentUpdatedNotification : INotification
	{
		public ApiEventStudentServerResponseModel Record { get; private set; }

		public EventStudentUpdatedNotification(ApiEventStudentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EventStudentDeletedNotification : INotification
	{
		public int EventId { get; private set; }

		public EventStudentDeletedNotification(int eventId)
		{
			this.EventId = eventId;
		}
	}
}

/*<Codenesium>
    <Hash>b1523c6d89effc7606999145f0d04c64</Hash>
</Codenesium>*/