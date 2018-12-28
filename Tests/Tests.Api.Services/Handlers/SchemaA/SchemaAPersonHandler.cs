using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class SchemaAPersonCreatedHandler : INotificationHandler<SchemaAPersonCreatedNotification>
	{
		public async Task Handle(SchemaAPersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaAPersonUpdatedHandler : INotificationHandler<SchemaAPersonUpdatedNotification>
	{
		public async Task Handle(SchemaAPersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaAPersonDeletedHandler : INotificationHandler<SchemaAPersonDeletedNotification>
	{
		public async Task Handle(SchemaAPersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaAPersonCreatedNotification : INotification
	{
		public ApiSchemaAPersonServerResponseModel Record { get; private set; }

		public SchemaAPersonCreatedNotification(ApiSchemaAPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SchemaAPersonUpdatedNotification : INotification
	{
		public ApiSchemaAPersonServerResponseModel Record { get; private set; }

		public SchemaAPersonUpdatedNotification(ApiSchemaAPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SchemaAPersonDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SchemaAPersonDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>fbcf2171b503e8c6db8ce56be9fbf675</Hash>
</Codenesium>*/