using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductSubcategoryCreatedHandler : INotificationHandler<ProductSubcategoryCreatedNotification>
	{
		public async Task Handle(ProductSubcategoryCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductSubcategoryUpdatedHandler : INotificationHandler<ProductSubcategoryUpdatedNotification>
	{
		public async Task Handle(ProductSubcategoryUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductSubcategoryDeletedHandler : INotificationHandler<ProductSubcategoryDeletedNotification>
	{
		public async Task Handle(ProductSubcategoryDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductSubcategoryCreatedNotification : INotification
	{
		public ApiProductSubcategoryServerResponseModel Record { get; private set; }

		public ProductSubcategoryCreatedNotification(ApiProductSubcategoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductSubcategoryUpdatedNotification : INotification
	{
		public ApiProductSubcategoryServerResponseModel Record { get; private set; }

		public ProductSubcategoryUpdatedNotification(ApiProductSubcategoryServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductSubcategoryDeletedNotification : INotification
	{
		public int ProductSubcategoryID { get; private set; }

		public ProductSubcategoryDeletedNotification(int productSubcategoryID)
		{
			this.ProductSubcategoryID = productSubcategoryID;
		}
	}
}

/*<Codenesium>
    <Hash>e70fc50018cc0b312869fe39fb3aa9d7</Hash>
</Codenesium>*/