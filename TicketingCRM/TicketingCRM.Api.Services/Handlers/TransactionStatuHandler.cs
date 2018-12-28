using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TransactionStatuCreatedHandler : INotificationHandler<TransactionStatuCreatedNotification>
	{
		public async Task Handle(TransactionStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatuUpdatedHandler : INotificationHandler<TransactionStatuUpdatedNotification>
	{
		public async Task Handle(TransactionStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatuDeletedHandler : INotificationHandler<TransactionStatuDeletedNotification>
	{
		public async Task Handle(TransactionStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionStatuCreatedNotification : INotification
	{
		public ApiTransactionStatuServerResponseModel Record { get; private set; }

		public TransactionStatuCreatedNotification(ApiTransactionStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionStatuUpdatedNotification : INotification
	{
		public ApiTransactionStatuServerResponseModel Record { get; private set; }

		public TransactionStatuUpdatedNotification(ApiTransactionStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TransactionStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>8796b25747b34ef9d02449cb01fc549d</Hash>
</Codenesium>*/