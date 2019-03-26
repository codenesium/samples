using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CurrencyCreatedHandler : INotificationHandler<CurrencyCreatedNotification>
	{
		public async Task Handle(CurrencyCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyUpdatedHandler : INotificationHandler<CurrencyUpdatedNotification>
	{
		public async Task Handle(CurrencyUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyDeletedHandler : INotificationHandler<CurrencyDeletedNotification>
	{
		public async Task Handle(CurrencyDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyCreatedNotification : INotification
	{
		public ApiCurrencyServerResponseModel Record { get; private set; }

		public CurrencyCreatedNotification(ApiCurrencyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CurrencyUpdatedNotification : INotification
	{
		public ApiCurrencyServerResponseModel Record { get; private set; }

		public CurrencyUpdatedNotification(ApiCurrencyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CurrencyDeletedNotification : INotification
	{
		public string CurrencyCode { get; private set; }

		public CurrencyDeletedNotification(string currencyCode)
		{
			this.CurrencyCode = currencyCode;
		}
	}
}

/*<Codenesium>
    <Hash>00cc5cecb1242f4515216e9986b4278a</Hash>
</Codenesium>*/