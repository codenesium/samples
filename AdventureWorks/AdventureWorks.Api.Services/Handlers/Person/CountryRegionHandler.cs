using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CountryRegionCreatedHandler : INotificationHandler<CountryRegionCreatedNotification>
	{
		public async Task Handle(CountryRegionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRegionUpdatedHandler : INotificationHandler<CountryRegionUpdatedNotification>
	{
		public async Task Handle(CountryRegionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRegionDeletedHandler : INotificationHandler<CountryRegionDeletedNotification>
	{
		public async Task Handle(CountryRegionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRegionCreatedNotification : INotification
	{
		public ApiCountryRegionServerResponseModel Record { get; private set; }

		public CountryRegionCreatedNotification(ApiCountryRegionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryRegionUpdatedNotification : INotification
	{
		public ApiCountryRegionServerResponseModel Record { get; private set; }

		public CountryRegionUpdatedNotification(ApiCountryRegionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryRegionDeletedNotification : INotification
	{
		public string CountryRegionCode { get; private set; }

		public CountryRegionDeletedNotification(string countryRegionCode)
		{
			this.CountryRegionCode = countryRegionCode;
		}
	}
}

/*<Codenesium>
    <Hash>9827f6c8df897adb2bb948a697821f28</Hash>
</Codenesium>*/