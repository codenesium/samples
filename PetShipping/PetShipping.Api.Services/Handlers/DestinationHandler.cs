using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class DestinationCreatedHandler : INotificationHandler<DestinationCreatedNotification>
	{
		public async Task Handle(DestinationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DestinationUpdatedHandler : INotificationHandler<DestinationUpdatedNotification>
	{
		public async Task Handle(DestinationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DestinationDeletedHandler : INotificationHandler<DestinationDeletedNotification>
	{
		public async Task Handle(DestinationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DestinationCreatedNotification : INotification
	{
		public ApiDestinationServerResponseModel Record { get; private set; }

		public DestinationCreatedNotification(ApiDestinationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DestinationUpdatedNotification : INotification
	{
		public ApiDestinationServerResponseModel Record { get; private set; }

		public DestinationUpdatedNotification(ApiDestinationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DestinationDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public DestinationDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>40fcc12dfb19e581bc88ba036407a6a0</Hash>
</Codenesium>*/