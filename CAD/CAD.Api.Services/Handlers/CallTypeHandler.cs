using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallTypeCreatedHandler : INotificationHandler<CallTypeCreatedNotification>
	{
		public async Task Handle(CallTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallTypeUpdatedHandler : INotificationHandler<CallTypeUpdatedNotification>
	{
		public async Task Handle(CallTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallTypeDeletedHandler : INotificationHandler<CallTypeDeletedNotification>
	{
		public async Task Handle(CallTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallTypeCreatedNotification : INotification
	{
		public ApiCallTypeServerResponseModel Record { get; private set; }

		public CallTypeCreatedNotification(ApiCallTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallTypeUpdatedNotification : INotification
	{
		public ApiCallTypeServerResponseModel Record { get; private set; }

		public CallTypeUpdatedNotification(ApiCallTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallTypeDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallTypeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>8d171395d4b2d0fa46f9314370b7af75</Hash>
</Codenesium>*/