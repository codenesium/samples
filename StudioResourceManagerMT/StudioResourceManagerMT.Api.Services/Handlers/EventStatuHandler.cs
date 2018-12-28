using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
		public BOEventStatu Record { get; private set; }

		public EventStatuCreatedNotification(BOEventStatu record)
		{
			this.Record = record;
		}
	}

	public class EventStatuUpdatedNotification : INotification
	{
		public BOEventStatu Record { get; private set; }

		public EventStatuUpdatedNotification(BOEventStatu record)
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
    <Hash>08785b83a7a551e56b96093051fd1848</Hash>
</Codenesium>*/