using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ShipMethodCreatedHandler : INotificationHandler<ShipMethodCreatedNotification>
	{
		public async Task Handle(ShipMethodCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShipMethodUpdatedHandler : INotificationHandler<ShipMethodUpdatedNotification>
	{
		public async Task Handle(ShipMethodUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShipMethodDeletedHandler : INotificationHandler<ShipMethodDeletedNotification>
	{
		public async Task Handle(ShipMethodDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShipMethodCreatedNotification : INotification
	{
		public ApiShipMethodServerResponseModel Record { get; private set; }

		public ShipMethodCreatedNotification(ApiShipMethodServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShipMethodUpdatedNotification : INotification
	{
		public ApiShipMethodServerResponseModel Record { get; private set; }

		public ShipMethodUpdatedNotification(ApiShipMethodServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShipMethodDeletedNotification : INotification
	{
		public int ShipMethodID { get; private set; }

		public ShipMethodDeletedNotification(int shipMethodID)
		{
			this.ShipMethodID = shipMethodID;
		}
	}
}

/*<Codenesium>
    <Hash>f2d15747e83bdeee175022025657bf0d</Hash>
</Codenesium>*/