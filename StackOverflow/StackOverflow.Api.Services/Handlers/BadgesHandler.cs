using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class BadgesCreatedHandler : INotificationHandler<BadgesCreatedNotification>
	{
		public async Task Handle(BadgesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgesUpdatedHandler : INotificationHandler<BadgesUpdatedNotification>
	{
		public async Task Handle(BadgesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgesDeletedHandler : INotificationHandler<BadgesDeletedNotification>
	{
		public async Task Handle(BadgesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BadgesCreatedNotification : INotification
	{
		public ApiBadgesServerResponseModel Record { get; private set; }

		public BadgesCreatedNotification(ApiBadgesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BadgesUpdatedNotification : INotification
	{
		public ApiBadgesServerResponseModel Record { get; private set; }

		public BadgesUpdatedNotification(ApiBadgesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BadgesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public BadgesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>bd1dc82a50d8db150bef241dcc3fd63b</Hash>
</Codenesium>*/