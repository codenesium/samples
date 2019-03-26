using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ShiftCreatedHandler : INotificationHandler<ShiftCreatedNotification>
	{
		public async Task Handle(ShiftCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShiftUpdatedHandler : INotificationHandler<ShiftUpdatedNotification>
	{
		public async Task Handle(ShiftUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShiftDeletedHandler : INotificationHandler<ShiftDeletedNotification>
	{
		public async Task Handle(ShiftDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShiftCreatedNotification : INotification
	{
		public ApiShiftServerResponseModel Record { get; private set; }

		public ShiftCreatedNotification(ApiShiftServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShiftUpdatedNotification : INotification
	{
		public ApiShiftServerResponseModel Record { get; private set; }

		public ShiftUpdatedNotification(ApiShiftServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShiftDeletedNotification : INotification
	{
		public int ShiftID { get; private set; }

		public ShiftDeletedNotification(int shiftID)
		{
			this.ShiftID = shiftID;
		}
	}
}

/*<Codenesium>
    <Hash>0873d59ccab008c71a136c13458e32e5</Hash>
</Codenesium>*/