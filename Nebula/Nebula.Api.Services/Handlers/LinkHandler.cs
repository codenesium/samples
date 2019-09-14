using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class LinkCreatedHandler : INotificationHandler<LinkCreatedNotification>
	{
		public async Task Handle(LinkCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkUpdatedHandler : INotificationHandler<LinkUpdatedNotification>
	{
		public async Task Handle(LinkUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkDeletedHandler : INotificationHandler<LinkDeletedNotification>
	{
		public async Task Handle(LinkDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkCreatedNotification : INotification
	{
		public ApiLinkServerResponseModel Record { get; private set; }

		public LinkCreatedNotification(ApiLinkServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkUpdatedNotification : INotification
	{
		public ApiLinkServerResponseModel Record { get; private set; }

		public LinkUpdatedNotification(ApiLinkServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public LinkDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>252bfe6c4383617203a74549b9a51979</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/