using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SalesTerritoryCreatedHandler : INotificationHandler<SalesTerritoryCreatedNotification>
	{
		public async Task Handle(SalesTerritoryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTerritoryUpdatedHandler : INotificationHandler<SalesTerritoryUpdatedNotification>
	{
		public async Task Handle(SalesTerritoryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTerritoryDeletedHandler : INotificationHandler<SalesTerritoryDeletedNotification>
	{
		public async Task Handle(SalesTerritoryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesTerritoryCreatedNotification : INotification
	{
		public ApiSalesTerritoryServerResponseModel Record { get; private set; }

		public SalesTerritoryCreatedNotification(ApiSalesTerritoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesTerritoryUpdatedNotification : INotification
	{
		public ApiSalesTerritoryServerResponseModel Record { get; private set; }

		public SalesTerritoryUpdatedNotification(ApiSalesTerritoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesTerritoryDeletedNotification : INotification
	{
		public int TerritoryID { get; private set; }

		public SalesTerritoryDeletedNotification(int territoryID)
		{
			this.TerritoryID = territoryID;
		}
	}
}

/*<Codenesium>
    <Hash>5ddc652f3dfce135c9a34130c2bcad9f</Hash>
</Codenesium>*/