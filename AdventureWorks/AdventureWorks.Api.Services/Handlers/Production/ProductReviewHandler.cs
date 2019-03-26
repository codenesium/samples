using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductReviewCreatedHandler : INotificationHandler<ProductReviewCreatedNotification>
	{
		public async Task Handle(ProductReviewCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductReviewUpdatedHandler : INotificationHandler<ProductReviewUpdatedNotification>
	{
		public async Task Handle(ProductReviewUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductReviewDeletedHandler : INotificationHandler<ProductReviewDeletedNotification>
	{
		public async Task Handle(ProductReviewDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductReviewCreatedNotification : INotification
	{
		public ApiProductReviewServerResponseModel Record { get; private set; }

		public ProductReviewCreatedNotification(ApiProductReviewServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductReviewUpdatedNotification : INotification
	{
		public ApiProductReviewServerResponseModel Record { get; private set; }

		public ProductReviewUpdatedNotification(ApiProductReviewServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductReviewDeletedNotification : INotification
	{
		public int ProductReviewID { get; private set; }

		public ProductReviewDeletedNotification(int productReviewID)
		{
			this.ProductReviewID = productReviewID;
		}
	}
}

/*<Codenesium>
    <Hash>f5cd2d15e604f7a47a73be3a28647a88</Hash>
</Codenesium>*/