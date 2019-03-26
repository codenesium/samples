using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class PhoneNumberTypeCreatedHandler : INotificationHandler<PhoneNumberTypeCreatedNotification>
	{
		public async Task Handle(PhoneNumberTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PhoneNumberTypeUpdatedHandler : INotificationHandler<PhoneNumberTypeUpdatedNotification>
	{
		public async Task Handle(PhoneNumberTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PhoneNumberTypeDeletedHandler : INotificationHandler<PhoneNumberTypeDeletedNotification>
	{
		public async Task Handle(PhoneNumberTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PhoneNumberTypeCreatedNotification : INotification
	{
		public ApiPhoneNumberTypeServerResponseModel Record { get; private set; }

		public PhoneNumberTypeCreatedNotification(ApiPhoneNumberTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PhoneNumberTypeUpdatedNotification : INotification
	{
		public ApiPhoneNumberTypeServerResponseModel Record { get; private set; }

		public PhoneNumberTypeUpdatedNotification(ApiPhoneNumberTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PhoneNumberTypeDeletedNotification : INotification
	{
		public int PhoneNumberTypeID { get; private set; }

		public PhoneNumberTypeDeletedNotification(int phoneNumberTypeID)
		{
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}
	}
}

/*<Codenesium>
    <Hash>47f419eb662055581702f6c2d8e0f41b</Hash>
</Codenesium>*/