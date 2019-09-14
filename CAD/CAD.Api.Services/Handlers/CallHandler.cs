using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallCreatedHandler : INotificationHandler<CallCreatedNotification>
	{
		public async Task Handle(CallCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallUpdatedHandler : INotificationHandler<CallUpdatedNotification>
	{
		public async Task Handle(CallUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallDeletedHandler : INotificationHandler<CallDeletedNotification>
	{
		public async Task Handle(CallDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallCreatedNotification : INotification
	{
		public ApiCallServerResponseModel Record { get; private set; }

		public CallCreatedNotification(ApiCallServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallUpdatedNotification : INotification
	{
		public ApiCallServerResponseModel Record { get; private set; }

		public CallUpdatedNotification(ApiCallServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>ec648f9064dd1a9313963cf5f6327943</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/