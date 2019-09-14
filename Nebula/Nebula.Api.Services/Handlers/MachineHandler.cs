using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class MachineCreatedHandler : INotificationHandler<MachineCreatedNotification>
	{
		public async Task Handle(MachineCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineUpdatedHandler : INotificationHandler<MachineUpdatedNotification>
	{
		public async Task Handle(MachineUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineDeletedHandler : INotificationHandler<MachineDeletedNotification>
	{
		public async Task Handle(MachineDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class MachineCreatedNotification : INotification
	{
		public ApiMachineServerResponseModel Record { get; private set; }

		public MachineCreatedNotification(ApiMachineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MachineUpdatedNotification : INotification
	{
		public ApiMachineServerResponseModel Record { get; private set; }

		public MachineUpdatedNotification(ApiMachineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class MachineDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public MachineDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7713535d36d594869e7cf6745abb42c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/