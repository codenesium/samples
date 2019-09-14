using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallPersonCreatedHandler : INotificationHandler<CallPersonCreatedNotification>
	{
		public async Task Handle(CallPersonCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallPersonUpdatedHandler : INotificationHandler<CallPersonUpdatedNotification>
	{
		public async Task Handle(CallPersonUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallPersonDeletedHandler : INotificationHandler<CallPersonDeletedNotification>
	{
		public async Task Handle(CallPersonDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallPersonCreatedNotification : INotification
	{
		public ApiCallPersonServerResponseModel Record { get; private set; }

		public CallPersonCreatedNotification(ApiCallPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallPersonUpdatedNotification : INotification
	{
		public ApiCallPersonServerResponseModel Record { get; private set; }

		public CallPersonUpdatedNotification(ApiCallPersonServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallPersonDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallPersonDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>6af8392d3cb6c91365cc758e5f933f2b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/