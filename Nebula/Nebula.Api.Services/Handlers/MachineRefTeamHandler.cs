using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class MachineRefTeamCreatedHandler : INotificationHandler<MachineRefTeamCreatedNotification>
	{
		public async Task Handle(MachineRefTeamCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineRefTeamUpdatedHandler : INotificationHandler<MachineRefTeamUpdatedNotification>
	{
		public async Task Handle(MachineRefTeamUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineRefTeamDeletedHandler : INotificationHandler<MachineRefTeamDeletedNotification>
	{
		public async Task Handle(MachineRefTeamDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineRefTeamCreatedNotification : INotification
	{
		public ApiMachineRefTeamServerResponseModel Record { get; private set; }

		public MachineRefTeamCreatedNotification(ApiMachineRefTeamServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MachineRefTeamUpdatedNotification : INotification
	{
		public ApiMachineRefTeamServerResponseModel Record { get; private set; }

		public MachineRefTeamUpdatedNotification(ApiMachineRefTeamServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MachineRefTeamDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public MachineRefTeamDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>971856b572c5c3422d3238c9ec0353d6</Hash>
</Codenesium>*/