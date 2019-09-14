using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
		public int Id { get; private set; }

		public EmployeeDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>44d11f4105e9b8c4bea213029e3d44d9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/