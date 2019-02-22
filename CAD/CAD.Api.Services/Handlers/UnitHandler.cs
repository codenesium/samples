using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class UnitCreatedHandler : INotificationHandler<UnitCreatedNotification>
	{
		public async Task Handle(UnitCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitUpdatedHandler : INotificationHandler<UnitUpdatedNotification>
	{
		public async Task Handle(UnitUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitDeletedHandler : INotificationHandler<UnitDeletedNotification>
	{
		public async Task Handle(UnitDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitCreatedNotification : INotification
	{
		public ApiUnitServerResponseModel Record { get; private set; }

		public UnitCreatedNotification(ApiUnitServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitUpdatedNotification : INotification
	{
		public ApiUnitServerResponseModel Record { get; private set; }

		public UnitUpdatedNotification(ApiUnitServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public UnitDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>94969f177a8b3e84376685686bf799ed</Hash>
</Codenesium>*/