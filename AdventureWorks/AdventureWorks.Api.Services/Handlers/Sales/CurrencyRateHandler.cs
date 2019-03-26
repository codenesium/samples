using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CurrencyRateCreatedHandler : INotificationHandler<CurrencyRateCreatedNotification>
	{
		public async Task Handle(CurrencyRateCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyRateUpdatedHandler : INotificationHandler<CurrencyRateUpdatedNotification>
	{
		public async Task Handle(CurrencyRateUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyRateDeletedHandler : INotificationHandler<CurrencyRateDeletedNotification>
	{
		public async Task Handle(CurrencyRateDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CurrencyRateCreatedNotification : INotification
	{
		public ApiCurrencyRateServerResponseModel Record { get; private set; }

		public CurrencyRateCreatedNotification(ApiCurrencyRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CurrencyRateUpdatedNotification : INotification
	{
		public ApiCurrencyRateServerResponseModel Record { get; private set; }

		public CurrencyRateUpdatedNotification(ApiCurrencyRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CurrencyRateDeletedNotification : INotification
	{
		public int CurrencyRateID { get; private set; }

		public CurrencyRateDeletedNotification(int currencyRateID)
		{
			this.CurrencyRateID = currencyRateID;
		}
	}
}

/*<Codenesium>
    <Hash>03d7f0aa4af030ea858120d6f1e874ac</Hash>
</Codenesium>*/