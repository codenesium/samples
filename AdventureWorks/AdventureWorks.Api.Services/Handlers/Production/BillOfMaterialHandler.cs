using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class BillOfMaterialCreatedHandler : INotificationHandler<BillOfMaterialCreatedNotification>
	{
		public async Task Handle(BillOfMaterialCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BillOfMaterialUpdatedHandler : INotificationHandler<BillOfMaterialUpdatedNotification>
	{
		public async Task Handle(BillOfMaterialUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BillOfMaterialDeletedHandler : INotificationHandler<BillOfMaterialDeletedNotification>
	{
		public async Task Handle(BillOfMaterialDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BillOfMaterialCreatedNotification : INotification
	{
		public ApiBillOfMaterialServerResponseModel Record { get; private set; }

		public BillOfMaterialCreatedNotification(ApiBillOfMaterialServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BillOfMaterialUpdatedNotification : INotification
	{
		public ApiBillOfMaterialServerResponseModel Record { get; private set; }

		public BillOfMaterialUpdatedNotification(ApiBillOfMaterialServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BillOfMaterialDeletedNotification : INotification
	{
		public int BillOfMaterialsID { get; private set; }

		public BillOfMaterialDeletedNotification(int billOfMaterialsID)
		{
			this.BillOfMaterialsID = billOfMaterialsID;
		}
	}
}

/*<Codenesium>
    <Hash>1e98d085057652ffd2c9b5162f555e02</Hash>
</Codenesium>*/