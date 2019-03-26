using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductProductPhotoCreatedHandler : INotificationHandler<ProductProductPhotoCreatedNotification>
	{
		public async Task Handle(ProductProductPhotoCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductProductPhotoUpdatedHandler : INotificationHandler<ProductProductPhotoUpdatedNotification>
	{
		public async Task Handle(ProductProductPhotoUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductProductPhotoDeletedHandler : INotificationHandler<ProductProductPhotoDeletedNotification>
	{
		public async Task Handle(ProductProductPhotoDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductProductPhotoCreatedNotification : INotification
	{
		public ApiProductProductPhotoServerResponseModel Record { get; private set; }

		public ProductProductPhotoCreatedNotification(ApiProductProductPhotoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductProductPhotoUpdatedNotification : INotification
	{
		public ApiProductProductPhotoServerResponseModel Record { get; private set; }

		public ProductProductPhotoUpdatedNotification(ApiProductProductPhotoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductProductPhotoDeletedNotification : INotification
	{
		public int ProductID { get; private set; }

		public ProductProductPhotoDeletedNotification(int productID)
		{
			this.ProductID = productID;
		}
	}
}

/*<Codenesium>
    <Hash>d4b0e04c54b45a8ef59424c2bf5cd33c</Hash>
</Codenesium>*/