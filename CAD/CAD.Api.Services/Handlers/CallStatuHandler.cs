using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallStatuCreatedHandler : INotificationHandler<CallStatuCreatedNotification>
	{
		public async Task Handle(CallStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatuUpdatedHandler : INotificationHandler<CallStatuUpdatedNotification>
	{
		public async Task Handle(CallStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatuDeletedHandler : INotificationHandler<CallStatuDeletedNotification>
	{
		public async Task Handle(CallStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatuCreatedNotification : INotification
	{
		public ApiCallStatuServerResponseModel Record { get; private set; }

		public CallStatuCreatedNotification(ApiCallStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallStatuUpdatedNotification : INotification
	{
		public ApiCallStatuServerResponseModel Record { get; private set; }

		public CallStatuUpdatedNotification(ApiCallStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1ea70e34694051f6f5674655e0e0e9b3</Hash>
</Codenesium>*/