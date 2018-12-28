using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CreditCardCreatedHandler : INotificationHandler<CreditCardCreatedNotification>
	{
		public async Task Handle(CreditCardCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CreditCardUpdatedHandler : INotificationHandler<CreditCardUpdatedNotification>
	{
		public async Task Handle(CreditCardUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CreditCardDeletedHandler : INotificationHandler<CreditCardDeletedNotification>
	{
		public async Task Handle(CreditCardDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CreditCardCreatedNotification : INotification
	{
		public ApiCreditCardServerResponseModel Record { get; private set; }

		public CreditCardCreatedNotification(ApiCreditCardServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CreditCardUpdatedNotification : INotification
	{
		public ApiCreditCardServerResponseModel Record { get; private set; }

		public CreditCardUpdatedNotification(ApiCreditCardServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CreditCardDeletedNotification : INotification
	{
		public int CreditCardID { get; private set; }

		public CreditCardDeletedNotification(int creditCardID)
		{
			this.CreditCardID = creditCardID;
		}
	}
}

/*<Codenesium>
    <Hash>0e68fb14054c0e7227afbaf9c4cb7d68</Hash>
</Codenesium>*/