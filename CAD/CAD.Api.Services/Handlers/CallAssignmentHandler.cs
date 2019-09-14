using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallAssignmentCreatedHandler : INotificationHandler<CallAssignmentCreatedNotification>
	{
		public async Task Handle(CallAssignmentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallAssignmentUpdatedHandler : INotificationHandler<CallAssignmentUpdatedNotification>
	{
		public async Task Handle(CallAssignmentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallAssignmentDeletedHandler : INotificationHandler<CallAssignmentDeletedNotification>
	{
		public async Task Handle(CallAssignmentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CallAssignmentCreatedNotification : INotification
	{
		public ApiCallAssignmentServerResponseModel Record { get; private set; }

		public CallAssignmentCreatedNotification(ApiCallAssignmentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallAssignmentUpdatedNotification : INotification
	{
		public ApiCallAssignmentServerResponseModel Record { get; private set; }

		public CallAssignmentUpdatedNotification(ApiCallAssignmentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CallAssignmentDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CallAssignmentDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>a43d8a1e1ae570e55ef394d5ca5fad48</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/