using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class TableCreatedHandler : INotificationHandler<TableCreatedNotification>
	{
		public async Task Handle(TableCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TableUpdatedHandler : INotificationHandler<TableUpdatedNotification>
	{
		public async Task Handle(TableUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TableDeletedHandler : INotificationHandler<TableDeletedNotification>
	{
		public async Task Handle(TableDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TableCreatedNotification : INotification
	{
		public ApiTableServerResponseModel Record { get; private set; }

		public TableCreatedNotification(ApiTableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TableUpdatedNotification : INotification
	{
		public ApiTableServerResponseModel Record { get; private set; }

		public TableUpdatedNotification(ApiTableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TableDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TableDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>e127595d8d2df1853ffb1d895cfe717c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/