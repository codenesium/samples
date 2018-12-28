using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SalesTaxRateCreatedHandler : INotificationHandler<SalesTaxRateCreatedNotification>
	{
		public async Task Handle(SalesTaxRateCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTaxRateUpdatedHandler : INotificationHandler<SalesTaxRateUpdatedNotification>
	{
		public async Task Handle(SalesTaxRateUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTaxRateDeletedHandler : INotificationHandler<SalesTaxRateDeletedNotification>
	{
		public async Task Handle(SalesTaxRateDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTaxRateCreatedNotification : INotification
	{
		public ApiSalesTaxRateServerResponseModel Record { get; private set; }

		public SalesTaxRateCreatedNotification(ApiSalesTaxRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesTaxRateUpdatedNotification : INotification
	{
		public ApiSalesTaxRateServerResponseModel Record { get; private set; }

		public SalesTaxRateUpdatedNotification(ApiSalesTaxRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesTaxRateDeletedNotification : INotification
	{
		public int SalesTaxRateID { get; private set; }

		public SalesTaxRateDeletedNotification(int salesTaxRateID)
		{
			this.SalesTaxRateID = salesTaxRateID;
		}
	}
}

/*<Codenesium>
    <Hash>da7863d522dcea122a3d5f8b52f46933</Hash>
</Codenesium>*/