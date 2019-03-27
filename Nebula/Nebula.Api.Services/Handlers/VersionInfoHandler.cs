using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class VersionInfoCreatedHandler : INotificationHandler<VersionInfoCreatedNotification>
	{
		public async Task Handle(VersionInfoCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VersionInfoUpdatedHandler : INotificationHandler<VersionInfoUpdatedNotification>
	{
		public async Task Handle(VersionInfoUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VersionInfoDeletedHandler : INotificationHandler<VersionInfoDeletedNotification>
	{
		public async Task Handle(VersionInfoDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VersionInfoCreatedNotification : INotification
	{
		public ApiVersionInfoServerResponseModel Record { get; private set; }

		public VersionInfoCreatedNotification(ApiVersionInfoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VersionInfoUpdatedNotification : INotification
	{
		public ApiVersionInfoServerResponseModel Record { get; private set; }

		public VersionInfoUpdatedNotification(ApiVersionInfoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VersionInfoDeletedNotification : INotification
	{
		public long Version { get; private set; }

		public VersionInfoDeletedNotification(long version)
		{
			this.Version = version;
		}
	}
}

/*<Codenesium>
    <Hash>6c17765415d66d1f9f11af95e214f29d</Hash>
</Codenesium>*/