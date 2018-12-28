using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TicketCreatedHandler : INotificationHandler<TicketCreatedNotification>
	{
		public async Task Handle(TicketCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketUpdatedHandler : INotificationHandler<TicketUpdatedNotification>
	{
		public async Task Handle(TicketUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketDeletedHandler : INotificationHandler<TicketDeletedNotification>
	{
		public async Task Handle(TicketDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TicketCreatedNotification : INotification
	{
		public ApiTicketServerResponseModel Record { get; private set; }

		public TicketCreatedNotification(ApiTicketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketUpdatedNotification : INotification
	{
		public ApiTicketServerResponseModel Record { get; private set; }

		public TicketUpdatedNotification(ApiTicketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TicketDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TicketDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>2b3da52696b812b56c94a192e22342d3</Hash>
</Codenesium>*/