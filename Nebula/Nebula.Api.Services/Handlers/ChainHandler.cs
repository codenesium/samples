using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ChainCreatedHandler : INotificationHandler<ChainCreatedNotification>
	{
		public async Task Handle(ChainCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainUpdatedHandler : INotificationHandler<ChainUpdatedNotification>
	{
		public async Task Handle(ChainUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainDeletedHandler : INotificationHandler<ChainDeletedNotification>
	{
		public async Task Handle(ChainDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainCreatedNotification : INotification
	{
		public ApiChainServerResponseModel Record { get; private set; }

		public ChainCreatedNotification(ApiChainServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ChainUpdatedNotification : INotification
	{
		public ApiChainServerResponseModel Record { get; private set; }

		public ChainUpdatedNotification(ApiChainServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ChainDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public ChainDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>a7e8c27a57d66b385c6d36a3d4174add</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/