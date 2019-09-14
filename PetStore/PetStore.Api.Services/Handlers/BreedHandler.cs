using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>7f6f214792ffc874e842ca05658d0ae7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/