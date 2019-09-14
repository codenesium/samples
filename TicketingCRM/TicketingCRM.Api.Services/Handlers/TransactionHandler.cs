using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class TransactionCreatedHandler : INotificationHandler<TransactionCreatedNotification>
	{
		public async Task Handle(TransactionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionUpdatedHandler : INotificationHandler<TransactionUpdatedNotification>
	{
		public async Task Handle(TransactionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionDeletedHandler : INotificationHandler<TransactionDeletedNotification>
	{
		public async Task Handle(TransactionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TransactionCreatedNotification : INotification
	{
		public ApiTransactionServerResponseModel Record { get; private set; }

		public TransactionCreatedNotification(ApiTransactionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionUpdatedNotification : INotification
	{
		public ApiTransactionServerResponseModel Record { get; private set; }

		public TransactionUpdatedNotification(ApiTransactionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TransactionDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TransactionDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>cda92abe8fb7643686eb10222fdd2208</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/