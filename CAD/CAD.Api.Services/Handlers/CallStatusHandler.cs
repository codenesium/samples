using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallStatusCreatedHandler : INotificationHandler<CallStatusCreatedNotification>
	{
		public async Task Handle(CallStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatusUpdatedHandler : INotificationHandler<CallStatusUpdatedNotification>
	{
		public async Task Handle(CallStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatusDeletedHandler : INotificationHandler<CallStatusDeletedNotification>
	{
		public async Task Handle(CallStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallStatusCreatedNotification : INotification
	{
		public ApiCallStatusServerResponseModel Record { get; private set; }

		public CallStatusCreatedNotification(ApiCallStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallStatusUpdatedNotification : INotification
	{
		public ApiCallStatusServerResponseModel Record { get; private set; }

		public CallStatusUpdatedNotification(ApiCallStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>2502e9c6992e8f1000d3eb49058fb779</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/