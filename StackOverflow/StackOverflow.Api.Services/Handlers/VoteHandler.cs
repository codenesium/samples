using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class VoteCreatedHandler : INotificationHandler<VoteCreatedNotification>
	{
		public async Task Handle(VoteCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteUpdatedHandler : INotificationHandler<VoteUpdatedNotification>
	{
		public async Task Handle(VoteUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteDeletedHandler : INotificationHandler<VoteDeletedNotification>
	{
		public async Task Handle(VoteDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteCreatedNotification : INotification
	{
		public ApiVoteServerResponseModel Record { get; private set; }

		public VoteCreatedNotification(ApiVoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteUpdatedNotification : INotification
	{
		public ApiVoteServerResponseModel Record { get; private set; }

		public VoteUpdatedNotification(ApiVoteServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VoteDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>c43ad362629babe5405cb47e68fb4cc6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/