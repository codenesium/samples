using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class LinkStatusCreatedHandler : INotificationHandler<LinkStatusCreatedNotification>
	{
		public async Task Handle(LinkStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkStatusUpdatedHandler : INotificationHandler<LinkStatusUpdatedNotification>
	{
		public async Task Handle(LinkStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkStatusDeletedHandler : INotificationHandler<LinkStatusDeletedNotification>
	{
		public async Task Handle(LinkStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkStatusCreatedNotification : INotification
	{
		public ApiLinkStatusServerResponseModel Record { get; private set; }

		public LinkStatusCreatedNotification(ApiLinkStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkStatusUpdatedNotification : INotification
	{
		public ApiLinkStatusServerResponseModel Record { get; private set; }

		public LinkStatusUpdatedNotification(ApiLinkStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public LinkStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1c428cc24a788eb894b5f5be0921a29c</Hash>
</Codenesium>*/