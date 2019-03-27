using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class SaleTicketsCreatedHandler : INotificationHandler<SaleTicketsCreatedNotification>
	{
		public async Task Handle(SaleTicketsCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketsUpdatedHandler : INotificationHandler<SaleTicketsUpdatedNotification>
	{
		public async Task Handle(SaleTicketsUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketsDeletedHandler : INotificationHandler<SaleTicketsDeletedNotification>
	{
		public async Task Handle(SaleTicketsDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleTicketsCreatedNotification : INotification
	{
		public ApiSaleTicketsServerResponseModel Record { get; private set; }

		public SaleTicketsCreatedNotification(ApiSaleTicketsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleTicketsUpdatedNotification : INotification
	{
		public ApiSaleTicketsServerResponseModel Record { get; private set; }

		public SaleTicketsUpdatedNotification(ApiSaleTicketsServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleTicketsDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SaleTicketsDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>c52c260059516e6be73fae28e481af8d</Hash>
</Codenesium>*/