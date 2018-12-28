using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductCreatedHandler : INotificationHandler<ProductCreatedNotification>
	{
		public async Task Handle(ProductCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductUpdatedHandler : INotificationHandler<ProductUpdatedNotification>
	{
		public async Task Handle(ProductUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductDeletedHandler : INotificationHandler<ProductDeletedNotification>
	{
		public async Task Handle(ProductDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductCreatedNotification : INotification
	{
		public ApiProductServerResponseModel Record { get; private set; }

		public ProductCreatedNotification(ApiProductServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductUpdatedNotification : INotification
	{
		public ApiProductServerResponseModel Record { get; private set; }

		public ProductUpdatedNotification(ApiProductServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductDeletedNotification : INotification
	{
		public int ProductID { get; private set; }

		public ProductDeletedNotification(int productID)
		{
			this.ProductID = productID;
		}
	}
}

/*<Codenesium>
    <Hash>6e89268cfd9ff34f9c40998044d64d8b</Hash>
</Codenesium>*/