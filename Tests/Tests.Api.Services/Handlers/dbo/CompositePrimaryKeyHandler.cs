using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.Services
{
	public class CompositePrimaryKeyCreatedHandler : INotificationHandler<CompositePrimaryKeyCreatedNotification>
	{
		public async Task Handle(CompositePrimaryKeyCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CompositePrimaryKeyUpdatedHandler : INotificationHandler<CompositePrimaryKeyUpdatedNotification>
	{
		public async Task Handle(CompositePrimaryKeyUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CompositePrimaryKeyDeletedHandler : INotificationHandler<CompositePrimaryKeyDeletedNotification>
	{
		public async Task Handle(CompositePrimaryKeyDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CompositePrimaryKeyCreatedNotification : INotification
	{
		public ApiCompositePrimaryKeyServerResponseModel Record { get; private set; }

		public CompositePrimaryKeyCreatedNotification(ApiCompositePrimaryKeyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CompositePrimaryKeyUpdatedNotification : INotification
	{
		public ApiCompositePrimaryKeyServerResponseModel Record { get; private set; }

		public CompositePrimaryKeyUpdatedNotification(ApiCompositePrimaryKeyServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CompositePrimaryKeyDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CompositePrimaryKeyDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>307665a40c1bc35438f7551bdbe2e14c</Hash>
</Codenesium>*/