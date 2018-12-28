using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductModelCreatedHandler : INotificationHandler<ProductModelCreatedNotification>
	{
		public async Task Handle(ProductModelCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductModelUpdatedHandler : INotificationHandler<ProductModelUpdatedNotification>
	{
		public async Task Handle(ProductModelUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductModelDeletedHandler : INotificationHandler<ProductModelDeletedNotification>
	{
		public async Task Handle(ProductModelDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductModelCreatedNotification : INotification
	{
		public ApiProductModelServerResponseModel Record { get; private set; }

		public ProductModelCreatedNotification(ApiProductModelServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductModelUpdatedNotification : INotification
	{
		public ApiProductModelServerResponseModel Record { get; private set; }

		public ProductModelUpdatedNotification(ApiProductModelServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductModelDeletedNotification : INotification
	{
		public int ProductModelID { get; private set; }

		public ProductModelDeletedNotification(int productModelID)
		{
			this.ProductModelID = productModelID;
		}
	}
}

/*<Codenesium>
    <Hash>2201992f5ff696b67b8fe535fc7a8de9</Hash>
</Codenesium>*/