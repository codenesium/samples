using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.Services
{
	public class MessengerCreatedHandler : INotificationHandler<MessengerCreatedNotification>
	{
		public async Task Handle(MessengerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessengerUpdatedHandler : INotificationHandler<MessengerUpdatedNotification>
	{
		public async Task Handle(MessengerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessengerDeletedHandler : INotificationHandler<MessengerDeletedNotification>
	{
		public async Task Handle(MessengerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MessengerCreatedNotification : INotification
	{
		public ApiMessengerServerResponseModel Record { get; private set; }

		public MessengerCreatedNotification(ApiMessengerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MessengerUpdatedNotification : INotification
	{
		public ApiMessengerServerResponseModel Record { get; private set; }

		public MessengerUpdatedNotification(ApiMessengerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MessengerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public MessengerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>32bbab6b57eea67895ceca7da5e183c3</Hash>
</Codenesium>*/