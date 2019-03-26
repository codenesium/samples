using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class VendorCreatedHandler : INotificationHandler<VendorCreatedNotification>
	{
		public async Task Handle(VendorCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VendorUpdatedHandler : INotificationHandler<VendorUpdatedNotification>
	{
		public async Task Handle(VendorUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VendorDeletedHandler : INotificationHandler<VendorDeletedNotification>
	{
		public async Task Handle(VendorDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VendorCreatedNotification : INotification
	{
		public ApiVendorServerResponseModel Record { get; private set; }

		public VendorCreatedNotification(ApiVendorServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VendorUpdatedNotification : INotification
	{
		public ApiVendorServerResponseModel Record { get; private set; }

		public VendorUpdatedNotification(ApiVendorServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VendorDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public VendorDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>7302374ab6140c13adb41265d8ffee2a</Hash>
</Codenesium>*/