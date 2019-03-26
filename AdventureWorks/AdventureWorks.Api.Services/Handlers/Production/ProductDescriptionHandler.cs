using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductDescriptionCreatedHandler : INotificationHandler<ProductDescriptionCreatedNotification>
	{
		public async Task Handle(ProductDescriptionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductDescriptionUpdatedHandler : INotificationHandler<ProductDescriptionUpdatedNotification>
	{
		public async Task Handle(ProductDescriptionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductDescriptionDeletedHandler : INotificationHandler<ProductDescriptionDeletedNotification>
	{
		public async Task Handle(ProductDescriptionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductDescriptionCreatedNotification : INotification
	{
		public ApiProductDescriptionServerResponseModel Record { get; private set; }

		public ProductDescriptionCreatedNotification(ApiProductDescriptionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductDescriptionUpdatedNotification : INotification
	{
		public ApiProductDescriptionServerResponseModel Record { get; private set; }

		public ProductDescriptionUpdatedNotification(ApiProductDescriptionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductDescriptionDeletedNotification : INotification
	{
		public int ProductDescriptionID { get; private set; }

		public ProductDescriptionDeletedNotification(int productDescriptionID)
		{
			this.ProductDescriptionID = productDescriptionID;
		}
	}
}

/*<Codenesium>
    <Hash>272ec273f7abe150d7d7e9caa6703c41</Hash>
</Codenesium>*/