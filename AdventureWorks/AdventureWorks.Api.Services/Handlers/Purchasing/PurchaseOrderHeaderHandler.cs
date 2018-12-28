using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class PurchaseOrderHeaderCreatedHandler : INotificationHandler<PurchaseOrderHeaderCreatedNotification>
	{
		public async Task Handle(PurchaseOrderHeaderCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PurchaseOrderHeaderUpdatedHandler : INotificationHandler<PurchaseOrderHeaderUpdatedNotification>
	{
		public async Task Handle(PurchaseOrderHeaderUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PurchaseOrderHeaderDeletedHandler : INotificationHandler<PurchaseOrderHeaderDeletedNotification>
	{
		public async Task Handle(PurchaseOrderHeaderDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PurchaseOrderHeaderCreatedNotification : INotification
	{
		public ApiPurchaseOrderHeaderServerResponseModel Record { get; private set; }

		public PurchaseOrderHeaderCreatedNotification(ApiPurchaseOrderHeaderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PurchaseOrderHeaderUpdatedNotification : INotification
	{
		public ApiPurchaseOrderHeaderServerResponseModel Record { get; private set; }

		public PurchaseOrderHeaderUpdatedNotification(ApiPurchaseOrderHeaderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PurchaseOrderHeaderDeletedNotification : INotification
	{
		public int PurchaseOrderID { get; private set; }

		public PurchaseOrderHeaderDeletedNotification(int purchaseOrderID)
		{
			this.PurchaseOrderID = purchaseOrderID;
		}
	}
}

/*<Codenesium>
    <Hash>3e756e1283b132f1e58ea75d17b37d84</Hash>
</Codenesium>*/