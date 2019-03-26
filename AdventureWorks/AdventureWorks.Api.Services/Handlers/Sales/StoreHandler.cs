using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class StoreCreatedHandler : INotificationHandler<StoreCreatedNotification>
	{
		public async Task Handle(StoreCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StoreUpdatedHandler : INotificationHandler<StoreUpdatedNotification>
	{
		public async Task Handle(StoreUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StoreDeletedHandler : INotificationHandler<StoreDeletedNotification>
	{
		public async Task Handle(StoreDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StoreCreatedNotification : INotification
	{
		public ApiStoreServerResponseModel Record { get; private set; }

		public StoreCreatedNotification(ApiStoreServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StoreUpdatedNotification : INotification
	{
		public ApiStoreServerResponseModel Record { get; private set; }

		public StoreUpdatedNotification(ApiStoreServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StoreDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public StoreDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>045e4e1a6bc747747f33efbeb9267d8b</Hash>
</Codenesium>*/