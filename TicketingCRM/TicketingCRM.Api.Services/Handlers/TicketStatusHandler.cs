using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TicketStatusCreatedHandler : INotificationHandler<TicketStatusCreatedNotification>
	{
		public async Task Handle(TicketStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatusUpdatedHandler : INotificationHandler<TicketStatusUpdatedNotification>
	{
		public async Task Handle(TicketStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatusDeletedHandler : INotificationHandler<TicketStatusDeletedNotification>
	{
		public async Task Handle(TicketStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketStatusCreatedNotification : INotification
	{
		public ApiTicketStatusServerResponseModel Record { get; private set; }

		public TicketStatusCreatedNotification(ApiTicketStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketStatusUpdatedNotification : INotification
	{
		public ApiTicketStatusServerResponseModel Record { get; private set; }

		public TicketStatusUpdatedNotification(ApiTicketStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TicketStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>db490beaab0014b4b20c60ee29c47fdb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/