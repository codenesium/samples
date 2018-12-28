using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class StateProvinceCreatedHandler : INotificationHandler<StateProvinceCreatedNotification>
	{
		public async Task Handle(StateProvinceCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StateProvinceUpdatedHandler : INotificationHandler<StateProvinceUpdatedNotification>
	{
		public async Task Handle(StateProvinceUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StateProvinceDeletedHandler : INotificationHandler<StateProvinceDeletedNotification>
	{
		public async Task Handle(StateProvinceDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StateProvinceCreatedNotification : INotification
	{
		public ApiStateProvinceServerResponseModel Record { get; private set; }

		public StateProvinceCreatedNotification(ApiStateProvinceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StateProvinceUpdatedNotification : INotification
	{
		public ApiStateProvinceServerResponseModel Record { get; private set; }

		public StateProvinceUpdatedNotification(ApiStateProvinceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StateProvinceDeletedNotification : INotification
	{
		public int StateProvinceID { get; private set; }

		public StateProvinceDeletedNotification(int stateProvinceID)
		{
			this.StateProvinceID = stateProvinceID;
		}
	}
}

/*<Codenesium>
    <Hash>783df2c4433894dce7f6e18c4fe2d736</Hash>
</Codenesium>*/