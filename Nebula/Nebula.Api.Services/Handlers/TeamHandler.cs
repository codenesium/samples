using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class TeamCreatedHandler : INotificationHandler<TeamCreatedNotification>
	{
		public async Task Handle(TeamCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeamUpdatedHandler : INotificationHandler<TeamUpdatedNotification>
	{
		public async Task Handle(TeamUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeamDeletedHandler : INotificationHandler<TeamDeletedNotification>
	{
		public async Task Handle(TeamDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TeamCreatedNotification : INotification
	{
		public ApiTeamServerResponseModel Record { get; private set; }

		public TeamCreatedNotification(ApiTeamServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeamUpdatedNotification : INotification
	{
		public ApiTeamServerResponseModel Record { get; private set; }

		public TeamUpdatedNotification(ApiTeamServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TeamDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TeamDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>2249f190f5eeb2b1a94e98b82b12c0d0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/