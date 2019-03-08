using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class LinkTypesCreatedHandler : INotificationHandler<LinkTypesCreatedNotification>
	{
		public async Task Handle(LinkTypesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypesUpdatedHandler : INotificationHandler<LinkTypesUpdatedNotification>
	{
		public async Task Handle(LinkTypesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypesDeletedHandler : INotificationHandler<LinkTypesDeletedNotification>
	{
		public async Task Handle(LinkTypesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypesCreatedNotification : INotification
	{
		public ApiLinkTypesServerResponseModel Record { get; private set; }

		public LinkTypesCreatedNotification(ApiLinkTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkTypesUpdatedNotification : INotification
	{
		public ApiLinkTypesServerResponseModel Record { get; private set; }

		public LinkTypesUpdatedNotification(ApiLinkTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkTypesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public LinkTypesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d0721d84e0964cc4edbd7ba710550bee</Hash>
</Codenesium>*/