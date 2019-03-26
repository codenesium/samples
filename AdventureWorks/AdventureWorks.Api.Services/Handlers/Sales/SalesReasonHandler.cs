using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SalesReasonCreatedHandler : INotificationHandler<SalesReasonCreatedNotification>
	{
		public async Task Handle(SalesReasonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesReasonUpdatedHandler : INotificationHandler<SalesReasonUpdatedNotification>
	{
		public async Task Handle(SalesReasonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesReasonDeletedHandler : INotificationHandler<SalesReasonDeletedNotification>
	{
		public async Task Handle(SalesReasonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SalesReasonCreatedNotification : INotification
	{
		public ApiSalesReasonServerResponseModel Record { get; private set; }

		public SalesReasonCreatedNotification(ApiSalesReasonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesReasonUpdatedNotification : INotification
	{
		public ApiSalesReasonServerResponseModel Record { get; private set; }

		public SalesReasonUpdatedNotification(ApiSalesReasonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SalesReasonDeletedNotification : INotification
	{
		public int SalesReasonID { get; private set; }

		public SalesReasonDeletedNotification(int salesReasonID)
		{
			this.SalesReasonID = salesReasonID;
		}
	}
}

/*<Codenesium>
    <Hash>202954d1260b8f3a1bc1e68d7234a45a</Hash>
</Codenesium>*/