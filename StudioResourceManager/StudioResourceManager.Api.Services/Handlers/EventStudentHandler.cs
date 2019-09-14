using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
		public int Id { get; private set; }

		public EventStudentDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>8d392b1326f342c8b93325d39b8d1c49</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/