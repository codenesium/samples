using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ProductPhotoCreatedHandler : INotificationHandler<ProductPhotoCreatedNotification>
	{
		public async Task Handle(ProductPhotoCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductPhotoUpdatedHandler : INotificationHandler<ProductPhotoUpdatedNotification>
	{
		public async Task Handle(ProductPhotoUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductPhotoDeletedHandler : INotificationHandler<ProductPhotoDeletedNotification>
	{
		public async Task Handle(ProductPhotoDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProductPhotoCreatedNotification : INotification
	{
		public ApiProductPhotoServerResponseModel Record { get; private set; }

		public ProductPhotoCreatedNotification(ApiProductPhotoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductPhotoUpdatedNotification : INotification
	{
		public ApiProductPhotoServerResponseModel Record { get; private set; }

		public ProductPhotoUpdatedNotification(ApiProductPhotoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProductPhotoDeletedNotification : INotification
	{
		public int ProductPhotoID { get; private set; }

		public ProductPhotoDeletedNotification(int productPhotoID)
		{
			this.ProductPhotoID = productPhotoID;
		}
	}
}

/*<Codenesium>
    <Hash>381ca5a996ebb5451eb3375d819a2382</Hash>
</Codenesium>*/