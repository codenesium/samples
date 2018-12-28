using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class CountryCreatedHandler : INotificationHandler<CountryCreatedNotification>
	{
		public async Task Handle(CountryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryUpdatedHandler : INotificationHandler<CountryUpdatedNotification>
	{
		public async Task Handle(CountryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryDeletedHandler : INotificationHandler<CountryDeletedNotification>
	{
		public async Task Handle(CountryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryCreatedNotification : INotification
	{
		public ApiCountryServerResponseModel Record { get; private set; }

		public CountryCreatedNotification(ApiCountryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryUpdatedNotification : INotification
	{
		public ApiCountryServerResponseModel Record { get; private set; }

		public CountryUpdatedNotification(ApiCountryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CountryDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>479f8e6c7508d1fab0e085e75be3ad46</Hash>
</Codenesium>*/