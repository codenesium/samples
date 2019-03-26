using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductCategoryCreatedHandler : INotificationHandler<ProductCategoryCreatedNotification>
	{
		public async Task Handle(ProductCategoryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductCategoryUpdatedHandler : INotificationHandler<ProductCategoryUpdatedNotification>
	{
		public async Task Handle(ProductCategoryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductCategoryDeletedHandler : INotificationHandler<ProductCategoryDeletedNotification>
	{
		public async Task Handle(ProductCategoryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductCategoryCreatedNotification : INotification
	{
		public ApiProductCategoryServerResponseModel Record { get; private set; }

		public ProductCategoryCreatedNotification(ApiProductCategoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductCategoryUpdatedNotification : INotification
	{
		public ApiProductCategoryServerResponseModel Record { get; private set; }

		public ProductCategoryUpdatedNotification(ApiProductCategoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductCategoryDeletedNotification : INotification
	{
		public int ProductCategoryID { get; private set; }

		public ProductCategoryDeletedNotification(int productCategoryID)
		{
			this.ProductCategoryID = productCategoryID;
		}
	}
}

/*<Codenesium>
    <Hash>3c1e8fc5140f08bde6c9f6ebd0642ea3</Hash>
</Codenesium>*/