using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SalesPersonCreatedHandler : INotificationHandler<SalesPersonCreatedNotification>
	{
		public async Task Handle(SalesPersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesPersonUpdatedHandler : INotificationHandler<SalesPersonUpdatedNotification>
	{
		public async Task Handle(SalesPersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesPersonDeletedHandler : INotificationHandler<SalesPersonDeletedNotification>
	{
		public async Task Handle(SalesPersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesPersonCreatedNotification : INotification
	{
		public ApiSalesPersonServerResponseModel Record { get; private set; }

		public SalesPersonCreatedNotification(ApiSalesPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesPersonUpdatedNotification : INotification
	{
		public ApiSalesPersonServerResponseModel Record { get; private set; }

		public SalesPersonUpdatedNotification(ApiSalesPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesPersonDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public SalesPersonDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>5aeaa7402dafbf921182ad0446010e67</Hash>
</Codenesium>*/