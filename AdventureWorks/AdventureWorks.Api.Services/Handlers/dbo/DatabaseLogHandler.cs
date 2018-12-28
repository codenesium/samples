using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class DatabaseLogCreatedHandler : INotificationHandler<DatabaseLogCreatedNotification>
	{
		public async Task Handle(DatabaseLogCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DatabaseLogUpdatedHandler : INotificationHandler<DatabaseLogUpdatedNotification>
	{
		public async Task Handle(DatabaseLogUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DatabaseLogDeletedHandler : INotificationHandler<DatabaseLogDeletedNotification>
	{
		public async Task Handle(DatabaseLogDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DatabaseLogCreatedNotification : INotification
	{
		public ApiDatabaseLogServerResponseModel Record { get; private set; }

		public DatabaseLogCreatedNotification(ApiDatabaseLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DatabaseLogUpdatedNotification : INotification
	{
		public ApiDatabaseLogServerResponseModel Record { get; private set; }

		public DatabaseLogUpdatedNotification(ApiDatabaseLogServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DatabaseLogDeletedNotification : INotification
	{
		public int DatabaseLogID { get; private set; }

		public DatabaseLogDeletedNotification(int databaseLogID)
		{
			this.DatabaseLogID = databaseLogID;
		}
	}
}

/*<Codenesium>
    <Hash>c27bea51cf8334595bf39b71369efe63</Hash>
</Codenesium>*/