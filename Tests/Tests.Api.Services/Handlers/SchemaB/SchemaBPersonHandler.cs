using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class SchemaBPersonCreatedHandler : INotificationHandler<SchemaBPersonCreatedNotification>
	{
		public async Task Handle(SchemaBPersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaBPersonUpdatedHandler : INotificationHandler<SchemaBPersonUpdatedNotification>
	{
		public async Task Handle(SchemaBPersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaBPersonDeletedHandler : INotificationHandler<SchemaBPersonDeletedNotification>
	{
		public async Task Handle(SchemaBPersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SchemaBPersonCreatedNotification : INotification
	{
		public ApiSchemaBPersonServerResponseModel Record { get; private set; }

		public SchemaBPersonCreatedNotification(ApiSchemaBPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SchemaBPersonUpdatedNotification : INotification
	{
		public ApiSchemaBPersonServerResponseModel Record { get; private set; }

		public SchemaBPersonUpdatedNotification(ApiSchemaBPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SchemaBPersonDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SchemaBPersonDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>67fec09d10ed83f87018c9f0b89edeca</Hash>
</Codenesium>*/