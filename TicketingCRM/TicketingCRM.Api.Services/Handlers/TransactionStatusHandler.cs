using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TransactionStatusCreatedHandler : INotificationHandler<TransactionStatusCreatedNotification>
	{
		public async Task Handle(TransactionStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatusUpdatedHandler : INotificationHandler<TransactionStatusUpdatedNotification>
	{
		public async Task Handle(TransactionStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatusDeletedHandler : INotificationHandler<TransactionStatusDeletedNotification>
	{
		public async Task Handle(TransactionStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatusCreatedNotification : INotification
	{
		public ApiTransactionStatusServerResponseModel Record { get; private set; }

		public TransactionStatusCreatedNotification(ApiTransactionStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionStatusUpdatedNotification : INotification
	{
		public ApiTransactionStatusServerResponseModel Record { get; private set; }

		public TransactionStatusUpdatedNotification(ApiTransactionStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TransactionStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>bca15b6d54f0d74c762de7f5d8f1b1f0</Hash>
</Codenesium>*/