using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class SaleCreatedHandler : INotificationHandler<SaleCreatedNotification>
	{
		public async Task Handle(SaleCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleUpdatedHandler : INotificationHandler<SaleUpdatedNotification>
	{
		public async Task Handle(SaleUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleDeletedHandler : INotificationHandler<SaleDeletedNotification>
	{
		public async Task Handle(SaleDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SaleCreatedNotification : INotification
	{
		public ApiSaleServerResponseModel Record { get; private set; }

		public SaleCreatedNotification(ApiSaleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleUpdatedNotification : INotification
	{
		public ApiSaleServerResponseModel Record { get; private set; }

		public SaleUpdatedNotification(ApiSaleServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SaleDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SaleDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>98e2d2c0043f09208cfa4c2dddfe7f1c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/