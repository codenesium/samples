using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallDispositionCreatedHandler : INotificationHandler<CallDispositionCreatedNotification>
	{
		public async Task Handle(CallDispositionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallDispositionUpdatedHandler : INotificationHandler<CallDispositionUpdatedNotification>
	{
		public async Task Handle(CallDispositionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallDispositionDeletedHandler : INotificationHandler<CallDispositionDeletedNotification>
	{
		public async Task Handle(CallDispositionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallDispositionCreatedNotification : INotification
	{
		public ApiCallDispositionServerResponseModel Record { get; private set; }

		public CallDispositionCreatedNotification(ApiCallDispositionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallDispositionUpdatedNotification : INotification
	{
		public ApiCallDispositionServerResponseModel Record { get; private set; }

		public CallDispositionUpdatedNotification(ApiCallDispositionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallDispositionDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallDispositionDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>cd728c69b10b16c4ef569d302747c16b</Hash>
</Codenesium>*/