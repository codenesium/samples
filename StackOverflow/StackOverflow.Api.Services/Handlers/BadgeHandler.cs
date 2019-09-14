using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class BadgeCreatedHandler : INotificationHandler<BadgeCreatedNotification>
	{
		public async Task Handle(BadgeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgeUpdatedHandler : INotificationHandler<BadgeUpdatedNotification>
	{
		public async Task Handle(BadgeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgeDeletedHandler : INotificationHandler<BadgeDeletedNotification>
	{
		public async Task Handle(BadgeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgeCreatedNotification : INotification
	{
		public ApiBadgeServerResponseModel Record { get; private set; }

		public BadgeCreatedNotification(ApiBadgeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BadgeUpdatedNotification : INotification
	{
		public ApiBadgeServerResponseModel Record { get; private set; }

		public BadgeUpdatedNotification(ApiBadgeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BadgeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public BadgeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>085cf9f9f64216cc4f4e76e33c67ecb5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/