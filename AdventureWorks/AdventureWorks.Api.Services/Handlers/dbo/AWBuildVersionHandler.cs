using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class AWBuildVersionCreatedHandler : INotificationHandler<AWBuildVersionCreatedNotification>
	{
		public async Task Handle(AWBuildVersionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AWBuildVersionUpdatedHandler : INotificationHandler<AWBuildVersionUpdatedNotification>
	{
		public async Task Handle(AWBuildVersionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AWBuildVersionDeletedHandler : INotificationHandler<AWBuildVersionDeletedNotification>
	{
		public async Task Handle(AWBuildVersionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AWBuildVersionCreatedNotification : INotification
	{
		public ApiAWBuildVersionServerResponseModel Record { get; private set; }

		public AWBuildVersionCreatedNotification(ApiAWBuildVersionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AWBuildVersionUpdatedNotification : INotification
	{
		public ApiAWBuildVersionServerResponseModel Record { get; private set; }

		public AWBuildVersionUpdatedNotification(ApiAWBuildVersionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AWBuildVersionDeletedNotification : INotification
	{
		public int SystemInformationID { get; private set; }

		public AWBuildVersionDeletedNotification(int systemInformationID)
		{
			this.SystemInformationID = systemInformationID;
		}
	}
}

/*<Codenesium>
    <Hash>c33219614841050e54e9061e098dbff9</Hash>
</Codenesium>*/