using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class ColumnSameAsFKTableCreatedHandler : INotificationHandler<ColumnSameAsFKTableCreatedNotification>
	{
		public async Task Handle(ColumnSameAsFKTableCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ColumnSameAsFKTableUpdatedHandler : INotificationHandler<ColumnSameAsFKTableUpdatedNotification>
	{
		public async Task Handle(ColumnSameAsFKTableUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ColumnSameAsFKTableDeletedHandler : INotificationHandler<ColumnSameAsFKTableDeletedNotification>
	{
		public async Task Handle(ColumnSameAsFKTableDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ColumnSameAsFKTableCreatedNotification : INotification
	{
		public ApiColumnSameAsFKTableServerResponseModel Record { get; private set; }

		public ColumnSameAsFKTableCreatedNotification(ApiColumnSameAsFKTableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ColumnSameAsFKTableUpdatedNotification : INotification
	{
		public ApiColumnSameAsFKTableServerResponseModel Record { get; private set; }

		public ColumnSameAsFKTableUpdatedNotification(ApiColumnSameAsFKTableServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ColumnSameAsFKTableDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public ColumnSameAsFKTableDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>872745ceba9d039a5995dd25da2296d7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/