using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class CountryRequirementCreatedHandler : INotificationHandler<CountryRequirementCreatedNotification>
	{
		public async Task Handle(CountryRequirementCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRequirementUpdatedHandler : INotificationHandler<CountryRequirementUpdatedNotification>
	{
		public async Task Handle(CountryRequirementUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRequirementDeletedHandler : INotificationHandler<CountryRequirementDeletedNotification>
	{
		public async Task Handle(CountryRequirementDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CountryRequirementCreatedNotification : INotification
	{
		public ApiCountryRequirementServerResponseModel Record { get; private set; }

		public CountryRequirementCreatedNotification(ApiCountryRequirementServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryRequirementUpdatedNotification : INotification
	{
		public ApiCountryRequirementServerResponseModel Record { get; private set; }

		public CountryRequirementUpdatedNotification(ApiCountryRequirementServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CountryRequirementDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CountryRequirementDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>168bfa22ddd3bfd5665ddb0ba8316924</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/