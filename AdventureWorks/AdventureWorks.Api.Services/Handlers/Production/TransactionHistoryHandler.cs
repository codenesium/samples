using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class TransactionHistoryCreatedHandler : INotificationHandler<TransactionHistoryCreatedNotification>
	{
		public async Task Handle(TransactionHistoryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryUpdatedHandler : INotificationHandler<TransactionHistoryUpdatedNotification>
	{
		public async Task Handle(TransactionHistoryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryDeletedHandler : INotificationHandler<TransactionHistoryDeletedNotification>
	{
		public async Task Handle(TransactionHistoryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryCreatedNotification : INotification
	{
		public ApiTransactionHistoryServerResponseModel Record { get; private set; }

		public TransactionHistoryCreatedNotification(ApiTransactionHistoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionHistoryUpdatedNotification : INotification
	{
		public ApiTransactionHistoryServerResponseModel Record { get; private set; }

		public TransactionHistoryUpdatedNotification(ApiTransactionHistoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionHistoryDeletedNotification : INotification
	{
		public int TransactionID { get; private set; }

		public TransactionHistoryDeletedNotification(int transactionID)
		{
			this.TransactionID = transactionID;
		}
	}
}

/*<Codenesium>
    <Hash>01fd77442a16ddbfb93621c25cc24dd2</Hash>
</Codenesium>*/