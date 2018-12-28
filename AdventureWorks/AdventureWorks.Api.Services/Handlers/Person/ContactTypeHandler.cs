using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ContactTypeCreatedHandler : INotificationHandler<ContactTypeCreatedNotification>
	{
		public async Task Handle(ContactTypeCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ContactTypeUpdatedHandler : INotificationHandler<ContactTypeUpdatedNotification>
	{
		public async Task Handle(ContactTypeUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ContactTypeDeletedHandler : INotificationHandler<ContactTypeDeletedNotification>
	{
		public async Task Handle(ContactTypeDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ContactTypeCreatedNotification : INotification
	{
		public ApiContactTypeServerResponseModel Record { get; private set; }

		public ContactTypeCreatedNotification(ApiContactTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ContactTypeUpdatedNotification : INotification
	{
		public ApiContactTypeServerResponseModel Record { get; private set; }

		public ContactTypeUpdatedNotification(ApiContactTypeServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ContactTypeDeletedNotification : INotification
	{
		public int ContactTypeID { get; private set; }

		public ContactTypeDeletedNotification(int contactTypeID)
		{
			this.ContactTypeID = contactTypeID;
		}
	}
}

/*<Codenesium>
    <Hash>10b304590265bc2b2ac4a2970cd14b3b</Hash>
</Codenesium>*/