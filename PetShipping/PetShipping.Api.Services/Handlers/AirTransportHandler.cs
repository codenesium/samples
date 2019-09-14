using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class AirTransportCreatedHandler : INotificationHandler<AirTransportCreatedNotification>
	{
		public async Task Handle(AirTransportCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirTransportUpdatedHandler : INotificationHandler<AirTransportUpdatedNotification>
	{
		public async Task Handle(AirTransportUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirTransportDeletedHandler : INotificationHandler<AirTransportDeletedNotification>
	{
		public async Task Handle(AirTransportDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AirTransportCreatedNotification : INotification
	{
		public ApiAirTransportServerResponseModel Record { get; private set; }

		public AirTransportCreatedNotification(ApiAirTransportServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AirTransportUpdatedNotification : INotification
	{
		public ApiAirTransportServerResponseModel Record { get; private set; }

		public AirTransportUpdatedNotification(ApiAirTransportServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AirTransportDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public AirTransportDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>e1f0d57d19aa368bef2741704aafbd27</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/