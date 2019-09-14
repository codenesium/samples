using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
		public int Id { get; private set; }

		public CustomerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>577b782f02d2daed612894eac4d59b16</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/