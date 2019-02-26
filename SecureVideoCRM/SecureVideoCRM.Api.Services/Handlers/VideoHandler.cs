using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class VideoCreatedHandler : INotificationHandler<VideoCreatedNotification>
	{
		public async Task Handle(VideoCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VideoUpdatedHandler : INotificationHandler<VideoUpdatedNotification>
	{
		public async Task Handle(VideoUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VideoDeletedHandler : INotificationHandler<VideoDeletedNotification>
	{
		public async Task Handle(VideoDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class VideoCreatedNotification : INotification
	{
		public ApiVideoServerResponseModel Record { get; private set; }

		public VideoCreatedNotification(ApiVideoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VideoUpdatedNotification : INotification
	{
		public ApiVideoServerResponseModel Record { get; private set; }

		public VideoUpdatedNotification(ApiVideoServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class VideoDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public VideoDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>655b7093a2222e0d41b634d70293afff</Hash>
</Codenesium>*/