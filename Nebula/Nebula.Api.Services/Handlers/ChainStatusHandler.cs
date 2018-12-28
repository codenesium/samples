using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ChainStatusCreatedHandler : INotificationHandler<ChainStatusCreatedNotification>
	{
		public async Task Handle(ChainStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainStatusUpdatedHandler : INotificationHandler<ChainStatusUpdatedNotification>
	{
		public async Task Handle(ChainStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainStatusDeletedHandler : INotificationHandler<ChainStatusDeletedNotification>
	{
		public async Task Handle(ChainStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ChainStatusCreatedNotification : INotification
	{
		public ApiChainStatusServerResponseModel Record { get; private set; }

		public ChainStatusCreatedNotification(ApiChainStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ChainStatusUpdatedNotification : INotification
	{
		public ApiChainStatusServerResponseModel Record { get; private set; }

		public ChainStatusUpdatedNotification(ApiChainStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ChainStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public ChainStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7baeded7340bf82cb317027cc96f0c50</Hash>
</Codenesium>*/