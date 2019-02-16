using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class SaleTicketCreatedHandler : INotificationHandler<SaleTicketCreatedNotification>
	{
		public async Task Handle(SaleTicketCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketUpdatedHandler : INotificationHandler<SaleTicketUpdatedNotification>
	{
		public async Task Handle(SaleTicketUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketDeletedHandler : INotificationHandler<SaleTicketDeletedNotification>
	{
		public async Task Handle(SaleTicketDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketCreatedNotification : INotification
	{
		public ApiSaleTicketServerResponseModel Record { get; private set; }

		public SaleTicketCreatedNotification(ApiSaleTicketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleTicketUpdatedNotification : INotification
	{
		public ApiSaleTicketServerResponseModel Record { get; private set; }

		public SaleTicketUpdatedNotification(ApiSaleTicketServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleTicketDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SaleTicketDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1fec9c79d7e636f5738babfa4dfb0938</Hash>
</Codenesium>*/