using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class LinkLogCreatedHandler : INotificationHandler<LinkLogCreatedNotification>
	{
		public async Task Handle(LinkLogCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkLogUpdatedHandler : INotificationHandler<LinkLogUpdatedNotification>
	{
		public async Task Handle(LinkLogUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkLogDeletedHandler : INotificationHandler<LinkLogDeletedNotification>
	{
		public async Task Handle(LinkLogDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkLogCreatedNotification : INotification
	{
		public ApiLinkLogServerResponseModel Record { get; private set; }

		public LinkLogCreatedNotification(ApiLinkLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkLogUpdatedNotification : INotification
	{
		public ApiLinkLogServerResponseModel Record { get; private set; }

		public LinkLogUpdatedNotification(ApiLinkLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkLogDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public LinkLogDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>6fcbf4ad4ba2a663d80ed2a644b8ac8f</Hash>
</Codenesium>*/