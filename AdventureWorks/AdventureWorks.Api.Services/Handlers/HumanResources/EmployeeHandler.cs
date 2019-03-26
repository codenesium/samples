using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class EmployeeCreatedHandler : INotificationHandler<EmployeeCreatedNotification>
	{
		public async Task Handle(EmployeeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EmployeeUpdatedHandler : INotificationHandler<EmployeeUpdatedNotification>
	{
		public async Task Handle(EmployeeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EmployeeDeletedHandler : INotificationHandler<EmployeeDeletedNotification>
	{
		public async Task Handle(EmployeeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class EmployeeCreatedNotification : INotification
	{
		public ApiEmployeeServerResponseModel Record { get; private set; }

		public EmployeeCreatedNotification(ApiEmployeeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EmployeeUpdatedNotification : INotification
	{
		public ApiEmployeeServerResponseModel Record { get; private set; }

		public EmployeeUpdatedNotification(ApiEmployeeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class EmployeeDeletedNotification : INotification
	{
		public int BusinessEntityID { get; private set; }

		public EmployeeDeletedNotification(int businessEntityID)
		{
			this.BusinessEntityID = businessEntityID;
		}
	}
}

/*<Codenesium>
    <Hash>0ff2d0ad9fb0021d8ef13810c04772b5</Hash>
</Codenesium>*/