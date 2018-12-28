using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class FileCreatedHandler : INotificationHandler<FileCreatedNotification>
	{
		public async Task Handle(FileCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileUpdatedHandler : INotificationHandler<FileUpdatedNotification>
	{
		public async Task Handle(FileUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileDeletedHandler : INotificationHandler<FileDeletedNotification>
	{
		public async Task Handle(FileDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileCreatedNotification : INotification
	{
		public ApiFileServerResponseModel Record { get; private set; }

		public FileCreatedNotification(ApiFileServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FileUpdatedNotification : INotification
	{
		public ApiFileServerResponseModel Record { get; private set; }

		public FileUpdatedNotification(ApiFileServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FileDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public FileDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>93d70bc14626ec49b64218066360066d</Hash>
</Codenesium>*/