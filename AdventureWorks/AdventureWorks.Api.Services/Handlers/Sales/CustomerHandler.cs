using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class CustomerCreatedHandler : INotificationHandler<CustomerCreatedNotification>
	{
		public async Task Handle(CustomerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerUpdatedHandler : INotificationHandler<CustomerUpdatedNotification>
	{
		public async Task Handle(CustomerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerDeletedHandler : INotificationHandler<CustomerDeletedNotification>
	{
		public async Task Handle(CustomerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerCreatedNotification : INotification
	{
		public ApiCustomerServerResponseModel Record { get; private set; }

		public CustomerCreatedNotification(ApiCustomerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CustomerUpdatedNotification : INotification
	{
		public ApiCustomerServerResponseModel Record { get; private set; }

		public CustomerUpdatedNotification(ApiCustomerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CustomerDeletedNotification : INotification
	{
		public int CustomerID { get; private set; }

		public CustomerDeletedNotification(int customerID)
		{
			this.CustomerID = customerID;
		}
	}
}

/*<Codenesium>
    <Hash>af4f753e5b6ff08789b2a308277b63a5</Hash>
</Codenesium>*/