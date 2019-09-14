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
		public int Id { get; private set; }

		public EventTeacherDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>217171393856a2491e6c051c0c5e7b95</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/