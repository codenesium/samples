using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
    <Hash>722d5ccaa87a3991ace6cdee39573e8d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/