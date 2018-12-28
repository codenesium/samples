using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class BreedCreatedHandler : INotificationHandler<BreedCreatedNotification>
	{
		public async Task Handle(BreedCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BreedUpdatedHandler : INotificationHandler<BreedUpdatedNotification>
	{
		public async Task Handle(BreedUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BreedDeletedHandler : INotificationHandler<BreedDeletedNotification>
	{
		public async Task Handle(BreedDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class BreedCreatedNotification : INotification
	{
		public ApiBreedServerResponseModel Record { get; private set; }

		public BreedCreatedNotification(ApiBreedServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BreedUpdatedNotification : INotification
	{
		public ApiBreedServerResponseModel Record { get; private set; }

		public BreedUpdatedNotification(ApiBreedServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class BreedDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public BreedDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>15539617813f39ea1fca3a444269b413</Hash>
</Codenesium>*/