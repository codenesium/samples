using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class SubscriptionCreatedHandler : INotificationHandler<SubscriptionCreatedNotification>
	{
		public async Task Handle(SubscriptionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SubscriptionUpdatedHandler : INotificationHandler<SubscriptionUpdatedNotification>
	{
		public async Task Handle(SubscriptionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SubscriptionDeletedHandler : INotificationHandler<SubscriptionDeletedNotification>
	{
		public async Task Handle(SubscriptionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SubscriptionCreatedNotification : INotification
	{
		public ApiSubscriptionServerResponseModel Record { get; private set; }

		public SubscriptionCreatedNotification(ApiSubscriptionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SubscriptionUpdatedNotification : INotification
	{
		public ApiSubscriptionServerResponseModel Record { get; private set; }

		public SubscriptionUpdatedNotification(ApiSubscriptionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SubscriptionDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SubscriptionDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>9e1824de1c50c2beac28ce3a7cc9739d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/