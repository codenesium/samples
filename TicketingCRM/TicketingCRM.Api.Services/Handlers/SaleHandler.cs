using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class SaleCreatedHandler : INotificationHandler<SaleCreatedNotification>
	{
		public async Task Handle(SaleCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleUpdatedHandler : INotificationHandler<SaleUpdatedNotification>
	{
		public async Task Handle(SaleUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleDeletedHandler : INotificationHandler<SaleDeletedNotification>
	{
		public async Task Handle(SaleDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleCreatedNotification : INotification
	{
		public ApiSaleServerResponseModel Record { get; private set; }

		public SaleCreatedNotification(ApiSaleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleUpdatedNotification : INotification
	{
		public ApiSaleServerResponseModel Record { get; private set; }

		public SaleUpdatedNotification(ApiSaleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SaleDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>fe6dde231f52d90ad08383156c037249</Hash>
</Codenesium>*/