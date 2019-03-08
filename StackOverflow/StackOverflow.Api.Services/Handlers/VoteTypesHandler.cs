using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class VoteTypesCreatedHandler : INotificationHandler<VoteTypesCreatedNotification>
	{
		public async Task Handle(VoteTypesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypesUpdatedHandler : INotificationHandler<VoteTypesUpdatedNotification>
	{
		public async Task Handle(VoteTypesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypesDeletedHandler : INotificationHandler<VoteTypesDeletedNotification>
	{
		public async Task Handle(VoteTypesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VoteTypesCreatedNotification : INotification
	{
		public ApiVoteTypesServerResponseModel Record { get; private set; }

		public VoteTypesCreatedNotification(ApiVoteTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteTypesUpdatedNotification : INotification
	{
		public ApiVoteTypesServerResponseModel Record { get; private set; }

		public VoteTypesUpdatedNotification(ApiVoteTypesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VoteTypesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VoteTypesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>6b7f295d79b1849c8d5937c8537b0cda</Hash>
</Codenesium>*/