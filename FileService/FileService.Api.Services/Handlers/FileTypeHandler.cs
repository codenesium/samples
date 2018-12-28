using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class FileTypeCreatedHandler : INotificationHandler<FileTypeCreatedNotification>
	{
		public async Task Handle(FileTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileTypeUpdatedHandler : INotificationHandler<FileTypeUpdatedNotification>
	{
		public async Task Handle(FileTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileTypeDeletedHandler : INotificationHandler<FileTypeDeletedNotification>
	{
		public async Task Handle(FileTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class FileTypeCreatedNotification : INotification
	{
		public ApiFileTypeServerResponseModel Record { get; private set; }

		public FileTypeCreatedNotification(ApiFileTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FileTypeUpdatedNotification : INotification
	{
		public ApiFileTypeServerResponseModel Record { get; private set; }

		public FileTypeUpdatedNotification(ApiFileTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class FileTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public FileTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1e027431addacee211a9df1c1a61907c</Hash>
</Codenesium>*/