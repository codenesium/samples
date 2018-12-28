using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class RowVersionCheckCreatedHandler : INotificationHandler<RowVersionCheckCreatedNotification>
	{
		public async Task Handle(RowVersionCheckCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RowVersionCheckUpdatedHandler : INotificationHandler<RowVersionCheckUpdatedNotification>
	{
		public async Task Handle(RowVersionCheckUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RowVersionCheckDeletedHandler : INotificationHandler<RowVersionCheckDeletedNotification>
	{
		public async Task Handle(RowVersionCheckDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RowVersionCheckCreatedNotification : INotification
	{
		public ApiRowVersionCheckServerResponseModel Record { get; private set; }

		public RowVersionCheckCreatedNotification(ApiRowVersionCheckServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RowVersionCheckUpdatedNotification : INotification
	{
		public ApiRowVersionCheckServerResponseModel Record { get; private set; }

		public RowVersionCheckUpdatedNotification(ApiRowVersionCheckServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RowVersionCheckDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public RowVersionCheckDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>6e747cad4629176f0694118b112ebcb5</Hash>
</Codenesium>*/