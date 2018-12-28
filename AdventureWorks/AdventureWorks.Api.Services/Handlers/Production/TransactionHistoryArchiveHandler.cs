using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class TransactionHistoryArchiveCreatedHandler : INotificationHandler<TransactionHistoryArchiveCreatedNotification>
	{
		public async Task Handle(TransactionHistoryArchiveCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryArchiveUpdatedHandler : INotificationHandler<TransactionHistoryArchiveUpdatedNotification>
	{
		public async Task Handle(TransactionHistoryArchiveUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryArchiveDeletedHandler : INotificationHandler<TransactionHistoryArchiveDeletedNotification>
	{
		public async Task Handle(TransactionHistoryArchiveDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionHistoryArchiveCreatedNotification : INotification
	{
		public ApiTransactionHistoryArchiveServerResponseModel Record { get; private set; }

		public TransactionHistoryArchiveCreatedNotification(ApiTransactionHistoryArchiveServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionHistoryArchiveUpdatedNotification : INotification
	{
		public ApiTransactionHistoryArchiveServerResponseModel Record { get; private set; }

		public TransactionHistoryArchiveUpdatedNotification(ApiTransactionHistoryArchiveServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionHistoryArchiveDeletedNotification : INotification
	{
		public int TransactionID { get; private set; }

		public TransactionHistoryArchiveDeletedNotification(int transactionID)
		{
			this.TransactionID = transactionID;
		}
	}
}

/*<Codenesium>
    <Hash>3f4db8a230cb30e37c86b2f44869e2da</Hash>
</Codenesium>*/