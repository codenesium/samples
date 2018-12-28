using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class CustomerCommunicationCreatedHandler : INotificationHandler<CustomerCommunicationCreatedNotification>
	{
		public async Task Handle(CustomerCommunicationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerCommunicationUpdatedHandler : INotificationHandler<CustomerCommunicationUpdatedNotification>
	{
		public async Task Handle(CustomerCommunicationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerCommunicationDeletedHandler : INotificationHandler<CustomerCommunicationDeletedNotification>
	{
		public async Task Handle(CustomerCommunicationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class CustomerCommunicationCreatedNotification : INotification
	{
		public ApiCustomerCommunicationServerResponseModel Record { get; private set; }

		public CustomerCommunicationCreatedNotification(ApiCustomerCommunicationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CustomerCommunicationUpdatedNotification : INotification
	{
		public ApiCustomerCommunicationServerResponseModel Record { get; private set; }

		public CustomerCommunicationUpdatedNotification(ApiCustomerCommunicationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class CustomerCommunicationDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public CustomerCommunicationDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>7cac5cae726e79fbf5c004d5756b8c76</Hash>
</Codenesium>*/