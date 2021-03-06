using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class RateCreatedHandler : INotificationHandler<RateCreatedNotification>
	{
		public async Task Handle(RateCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateUpdatedHandler : INotificationHandler<RateUpdatedNotification>
	{
		public async Task Handle(RateUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateDeletedHandler : INotificationHandler<RateDeletedNotification>
	{
		public async Task Handle(RateDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class RateCreatedNotification : INotification
	{
		public ApiRateServerResponseModel Record { get; private set; }

		public RateCreatedNotification(ApiRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RateUpdatedNotification : INotification
	{
		public ApiRateServerResponseModel Record { get; private set; }

		public RateUpdatedNotification(ApiRateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class RateDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public RateDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>e137053c4ae8c080aecedb3045e996b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/