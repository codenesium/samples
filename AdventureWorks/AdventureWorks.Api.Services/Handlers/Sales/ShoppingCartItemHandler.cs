using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ShoppingCartItemCreatedHandler : INotificationHandler<ShoppingCartItemCreatedNotification>
	{
		public async Task Handle(ShoppingCartItemCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShoppingCartItemUpdatedHandler : INotificationHandler<ShoppingCartItemUpdatedNotification>
	{
		public async Task Handle(ShoppingCartItemUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShoppingCartItemDeletedHandler : INotificationHandler<ShoppingCartItemDeletedNotification>
	{
		public async Task Handle(ShoppingCartItemDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ShoppingCartItemCreatedNotification : INotification
	{
		public ApiShoppingCartItemServerResponseModel Record { get; private set; }

		public ShoppingCartItemCreatedNotification(ApiShoppingCartItemServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShoppingCartItemUpdatedNotification : INotification
	{
		public ApiShoppingCartItemServerResponseModel Record { get; private set; }

		public ShoppingCartItemUpdatedNotification(ApiShoppingCartItemServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ShoppingCartItemDeletedNotification : INotification
	{
		public int ShoppingCartItemID { get; private set; }

		public ShoppingCartItemDeletedNotification(int shoppingCartItemID)
		{
			this.ShoppingCartItemID = shoppingCartItemID;
		}
	}
}

/*<Codenesium>
    <Hash>b35928b0cbdd98490de95039e540af66</Hash>
</Codenesium>*/