using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class CityCreatedHandler : INotificationHandler<CityCreatedNotification>
	{
		public async Task Handle(CityCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CityUpdatedHandler : INotificationHandler<CityUpdatedNotification>
	{
		public async Task Handle(CityUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CityDeletedHandler : INotificationHandler<CityDeletedNotification>
	{
		public async Task Handle(CityDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CityCreatedNotification : INotification
	{
		public ApiCityServerResponseModel Record { get; private set; }

		public CityCreatedNotification(ApiCityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CityUpdatedNotification : INotification
	{
		public ApiCityServerResponseModel Record { get; private set; }

		public CityUpdatedNotification(ApiCityServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CityDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CityDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>3120cb878964b4d36050de6b3d65dfd1</Hash>
</Codenesium>*/