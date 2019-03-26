using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class VoteTypeCreatedHandler : INotificationHandler<VoteTypeCreatedNotification>
	{
		public async Task Handle(VoteTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypeUpdatedHandler : INotificationHandler<VoteTypeUpdatedNotification>
	{
		public async Task Handle(VoteTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypeDeletedHandler : INotificationHandler<VoteTypeDeletedNotification>
	{
		public async Task Handle(VoteTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypeCreatedNotification : INotification
	{
		public ApiVoteTypeServerResponseModel Record { get; private set; }

		public VoteTypeCreatedNotification(ApiVoteTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteTypeUpdatedNotification : INotification
	{
		public ApiVoteTypeServerResponseModel Record { get; private set; }

		public VoteTypeUpdatedNotification(ApiVoteTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VoteTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>fdcd1faac340312fb5d720013506d3fa</Hash>
</Codenesium>*/