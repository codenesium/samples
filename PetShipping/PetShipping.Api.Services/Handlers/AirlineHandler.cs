using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class AirlineCreatedHandler : INotificationHandler<AirlineCreatedNotification>
	{
		public async Task Handle(AirlineCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirlineUpdatedHandler : INotificationHandler<AirlineUpdatedNotification>
	{
		public async Task Handle(AirlineUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirlineDeletedHandler : INotificationHandler<AirlineDeletedNotification>
	{
		public async Task Handle(AirlineDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirlineCreatedNotification : INotification
	{
		public ApiAirlineServerResponseModel Record { get; private set; }

		public AirlineCreatedNotification(ApiAirlineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AirlineUpdatedNotification : INotification
	{
		public ApiAirlineServerResponseModel Record { get; private set; }

		public AirlineUpdatedNotification(ApiAirlineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AirlineDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public AirlineDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>8fecb73a40805d89e33715606ada3e95</Hash>
</Codenesium>*/