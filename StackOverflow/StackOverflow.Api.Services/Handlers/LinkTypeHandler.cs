using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class LinkTypeCreatedHandler : INotificationHandler<LinkTypeCreatedNotification>
	{
		public async Task Handle(LinkTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypeUpdatedHandler : INotificationHandler<LinkTypeUpdatedNotification>
	{
		public async Task Handle(LinkTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypeDeletedHandler : INotificationHandler<LinkTypeDeletedNotification>
	{
		public async Task Handle(LinkTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class LinkTypeCreatedNotification : INotification
	{
		public ApiLinkTypeServerResponseModel Record { get; private set; }

		public LinkTypeCreatedNotification(ApiLinkTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkTypeUpdatedNotification : INotification
	{
		public ApiLinkTypeServerResponseModel Record { get; private set; }

		public LinkTypeUpdatedNotification(ApiLinkTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class LinkTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public LinkTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>db2bdaed8ee38008d966e3565689abc1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/