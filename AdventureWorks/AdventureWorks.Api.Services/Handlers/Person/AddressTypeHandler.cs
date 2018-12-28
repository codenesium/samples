using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class AddressTypeCreatedHandler : INotificationHandler<AddressTypeCreatedNotification>
	{
		public async Task Handle(AddressTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressTypeUpdatedHandler : INotificationHandler<AddressTypeUpdatedNotification>
	{
		public async Task Handle(AddressTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressTypeDeletedHandler : INotificationHandler<AddressTypeDeletedNotification>
	{
		public async Task Handle(AddressTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AddressTypeCreatedNotification : INotification
	{
		public ApiAddressTypeServerResponseModel Record { get; private set; }

		public AddressTypeCreatedNotification(ApiAddressTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AddressTypeUpdatedNotification : INotification
	{
		public ApiAddressTypeServerResponseModel Record { get; private set; }

		public AddressTypeUpdatedNotification(ApiAddressTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AddressTypeDeletedNotification : INotification
	{
		public int AddressTypeID { get; private set; }

		public AddressTypeDeletedNotification(int addressTypeID)
		{
			this.AddressTypeID = addressTypeID;
		}
	}
}

/*<Codenesium>
    <Hash>e0bc3e2692cc9102169f49368d38fe94</Hash>
</Codenesium>*/