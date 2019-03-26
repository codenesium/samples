using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class SpecialOfferCreatedHandler : INotificationHandler<SpecialOfferCreatedNotification>
	{
		public async Task Handle(SpecialOfferCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpecialOfferUpdatedHandler : INotificationHandler<SpecialOfferUpdatedNotification>
	{
		public async Task Handle(SpecialOfferUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpecialOfferDeletedHandler : INotificationHandler<SpecialOfferDeletedNotification>
	{
		public async Task Handle(SpecialOfferDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpecialOfferCreatedNotification : INotification
	{
		public ApiSpecialOfferServerResponseModel Record { get; private set; }

		public SpecialOfferCreatedNotification(ApiSpecialOfferServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpecialOfferUpdatedNotification : INotification
	{
		public ApiSpecialOfferServerResponseModel Record { get; private set; }

		public SpecialOfferUpdatedNotification(ApiSpecialOfferServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpecialOfferDeletedNotification : INotification
	{
		public int SpecialOfferID { get; private set; }

		public SpecialOfferDeletedNotification(int specialOfferID)
		{
			this.SpecialOfferID = specialOfferID;
		}
	}
}

/*<Codenesium>
    <Hash>29be1562b0c293adf4d5f1c53cb55c8b</Hash>
</Codenesium>*/