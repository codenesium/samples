using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class WorkOrderCreatedHandler : INotificationHandler<WorkOrderCreatedNotification>
	{
		public async Task Handle(WorkOrderCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class WorkOrderUpdatedHandler : INotificationHandler<WorkOrderUpdatedNotification>
	{
		public async Task Handle(WorkOrderUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class WorkOrderDeletedHandler : INotificationHandler<WorkOrderDeletedNotification>
	{
		public async Task Handle(WorkOrderDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class WorkOrderCreatedNotification : INotification
	{
		public ApiWorkOrderServerResponseModel Record { get; private set; }

		public WorkOrderCreatedNotification(ApiWorkOrderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class WorkOrderUpdatedNotification : INotification
	{
		public ApiWorkOrderServerResponseModel Record { get; private set; }

		public WorkOrderUpdatedNotification(ApiWorkOrderServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class WorkOrderDeletedNotification : INotification
	{
		public int WorkOrderID { get; private set; }

		public WorkOrderDeletedNotification(int workOrderID)
		{
			this.WorkOrderID = workOrderID;
		}
	}
}

/*<Codenesium>
    <Hash>1a76315f90f8e946856377ecc2ebc67e</Hash>
</Codenesium>*/