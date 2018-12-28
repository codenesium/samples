using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class HandlerCreatedHandler : INotificationHandler<HandlerCreatedNotification>
	{
		public async Task Handle(HandlerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerUpdatedHandler : INotificationHandler<HandlerUpdatedNotification>
	{
		public async Task Handle(HandlerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerDeletedHandler : INotificationHandler<HandlerDeletedNotification>
	{
		public async Task Handle(HandlerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class HandlerCreatedNotification : INotification
	{
		public ApiHandlerServerResponseModel Record { get; private set; }

		public HandlerCreatedNotification(ApiHandlerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class HandlerUpdatedNotification : INotification
	{
		public ApiHandlerServerResponseModel Record { get; private set; }

		public HandlerUpdatedNotification(ApiHandlerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class HandlerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public HandlerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>56ac54faf29ae18c684fc078b477be34</Hash>
</Codenesium>*/