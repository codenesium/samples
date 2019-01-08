using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class StudioCreatedHandler : INotificationHandler<StudioCreatedNotification>
	{
		public async Task Handle(StudioCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioUpdatedHandler : INotificationHandler<StudioUpdatedNotification>
	{
		public async Task Handle(StudioUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioDeletedHandler : INotificationHandler<StudioDeletedNotification>
	{
		public async Task Handle(StudioDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class StudioCreatedNotification : INotification
	{
		public ApiStudioServerResponseModel Record { get; private set; }

		public StudioCreatedNotification(ApiStudioServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StudioUpdatedNotification : INotification
	{
		public ApiStudioServerResponseModel Record { get; private set; }

		public StudioUpdatedNotification(ApiStudioServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class StudioDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public StudioDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d744f7f390f03908eb25d4668527f476</Hash>
</Codenesium>*/