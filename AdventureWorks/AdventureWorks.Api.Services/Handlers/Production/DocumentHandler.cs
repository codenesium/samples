using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class DocumentCreatedHandler : INotificationHandler<DocumentCreatedNotification>
	{
		public async Task Handle(DocumentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DocumentUpdatedHandler : INotificationHandler<DocumentUpdatedNotification>
	{
		public async Task Handle(DocumentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DocumentDeletedHandler : INotificationHandler<DocumentDeletedNotification>
	{
		public async Task Handle(DocumentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DocumentCreatedNotification : INotification
	{
		public ApiDocumentServerResponseModel Record { get; private set; }

		public DocumentCreatedNotification(ApiDocumentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DocumentUpdatedNotification : INotification
	{
		public ApiDocumentServerResponseModel Record { get; private set; }

		public DocumentUpdatedNotification(ApiDocumentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DocumentDeletedNotification : INotification
	{
		public Guid Rowguid { get; private set; }

		public DocumentDeletedNotification(Guid rowguid)
		{
			this.Rowguid = rowguid;
		}
	}
}

/*<Codenesium>
    <Hash>c7f334e27f37b5281a1ba106f2a5e6c8</Hash>
</Codenesium>*/