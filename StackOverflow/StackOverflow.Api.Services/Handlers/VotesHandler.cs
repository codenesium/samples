using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class VotesCreatedHandler : INotificationHandler<VotesCreatedNotification>
	{
		public async Task Handle(VotesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VotesUpdatedHandler : INotificationHandler<VotesUpdatedNotification>
	{
		public async Task Handle(VotesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VotesDeletedHandler : INotificationHandler<VotesDeletedNotification>
	{
		public async Task Handle(VotesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VotesCreatedNotification : INotification
	{
		public ApiVotesServerResponseModel Record { get; private set; }

		public VotesCreatedNotification(ApiVotesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VotesUpdatedNotification : INotification
	{
		public ApiVotesServerResponseModel Record { get; private set; }

		public VotesUpdatedNotification(ApiVotesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VotesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VotesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>45cd7a9ef925ce029756e065770e28b3</Hash>
</Codenesium>*/