using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
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
		public int Id { get; private set; }

		public AddressDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>25335f8b470a7a8af50cb091ea7adb72</Hash>
</Codenesium>*/