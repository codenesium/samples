using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class AddressCreatedHandler : INotificationHandler<AddressCreatedNotification>
	{
		public async Task Handle(AddressCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressUpdatedHandler : INotificationHandler<AddressUpdatedNotification>
	{
		public async Task Handle(AddressUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressDeletedHandler : INotificationHandler<AddressDeletedNotification>
	{
		public async Task Handle(AddressDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressCreatedNotification : INotification
	{
		public ApiAddressServerResponseModel Record { get; private set; }

		public AddressCreatedNotification(ApiAddressServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AddressUpdatedNotification : INotification
	{
		public ApiAddressServerResponseModel Record { get; private set; }

		public AddressUpdatedNotification(ApiAddressServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AddressDeletedNotification : INotification
	{
		public int AddressID { get; private set; }

		public AddressDeletedNotification(int addressID)
		{
			this.AddressID = addressID;
		}
	}
}

/*<Codenesium>
    <Hash>d9d7052e70ad3693390ca78703dcde0a</Hash>
</Codenesium>*/