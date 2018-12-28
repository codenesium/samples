using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SalesOrderHeaderCreatedHandler : INotificationHandler<SalesOrderHeaderCreatedNotification>
	{
		public async Task Handle(SalesOrderHeaderCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesOrderHeaderUpdatedHandler : INotificationHandler<SalesOrderHeaderUpdatedNotification>
	{
		public async Task Handle(SalesOrderHeaderUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesOrderHeaderDeletedHandler : INotificationHandler<SalesOrderHeaderDeletedNotification>
	{
		public async Task Handle(SalesOrderHeaderDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesOrderHeaderCreatedNotification : INotification
	{
		public ApiSalesOrderHeaderServerResponseModel Record { get; private set; }

		public SalesOrderHeaderCreatedNotification(ApiSalesOrderHeaderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesOrderHeaderUpdatedNotification : INotification
	{
		public ApiSalesOrderHeaderServerResponseModel Record { get; private set; }

		public SalesOrderHeaderUpdatedNotification(ApiSalesOrderHeaderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesOrderHeaderDeletedNotification : INotification
	{
		public int SalesOrderID { get; private set; }

		public SalesOrderHeaderDeletedNotification(int salesOrderID)
		{
			this.SalesOrderID = salesOrderID;
		}
	}
}

/*<Codenesium>
    <Hash>dfecbe6f9d43e718a526b4bf5b280a22</Hash>
</Codenesium>*/