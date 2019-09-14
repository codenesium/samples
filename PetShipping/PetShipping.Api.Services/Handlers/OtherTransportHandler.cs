using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class OtherTransportCreatedHandler : INotificationHandler<OtherTransportCreatedNotification>
	{
		public async Task Handle(OtherTransportCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OtherTransportUpdatedHandler : INotificationHandler<OtherTransportUpdatedNotification>
	{
		public async Task Handle(OtherTransportUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OtherTransportDeletedHandler : INotificationHandler<OtherTransportDeletedNotification>
	{
		public async Task Handle(OtherTransportDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class OtherTransportCreatedNotification : INotification
	{
		public ApiOtherTransportServerResponseModel Record { get; private set; }

		public OtherTransportCreatedNotification(ApiOtherTransportServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OtherTransportUpdatedNotification : INotification
	{
		public ApiOtherTransportServerResponseModel Record { get; private set; }

		public OtherTransportUpdatedNotification(ApiOtherTransportServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class OtherTransportDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public OtherTransportDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f7c7270d6b0e2bdf53f91b23cf7b20b1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/