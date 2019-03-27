using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
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
		public int Id { get; private set; }

		public ProductDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d5a6d32f559f9bc4084f01131274b78c</Hash>
</Codenesium>*/