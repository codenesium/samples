using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class DepartmentCreatedHandler : INotificationHandler<DepartmentCreatedNotification>
	{
		public async Task Handle(DepartmentCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DepartmentUpdatedHandler : INotificationHandler<DepartmentUpdatedNotification>
	{
		public async Task Handle(DepartmentUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DepartmentDeletedHandler : INotificationHandler<DepartmentDeletedNotification>
	{
		public async Task Handle(DepartmentDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class DepartmentCreatedNotification : INotification
	{
		public ApiDepartmentServerResponseModel Record { get; private set; }

		public DepartmentCreatedNotification(ApiDepartmentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DepartmentUpdatedNotification : INotification
	{
		public ApiDepartmentServerResponseModel Record { get; private set; }

		public DepartmentUpdatedNotification(ApiDepartmentServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class DepartmentDeletedNotification : INotification
	{
		public short DepartmentID { get; private set; }

		public DepartmentDeletedNotification(short departmentID)
		{
			this.DepartmentID = departmentID;
		}
	}
}

/*<Codenesium>
    <Hash>c7e4400152fa09ddf3079dca5697048f</Hash>
</Codenesium>*/