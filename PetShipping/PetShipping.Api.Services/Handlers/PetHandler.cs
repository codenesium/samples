using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PetCreatedHandler : INotificationHandler<PetCreatedNotification>
	{
		public async Task Handle(PetCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PetUpdatedHandler : INotificationHandler<PetUpdatedNotification>
	{
		public async Task Handle(PetUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PetDeletedHandler : INotificationHandler<PetDeletedNotification>
	{
		public async Task Handle(PetDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PetCreatedNotification : INotification
	{
		public ApiPetServerResponseModel Record { get; private set; }

		public PetCreatedNotification(ApiPetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PetUpdatedNotification : INotification
	{
		public ApiPetServerResponseModel Record { get; private set; }

		public PetUpdatedNotification(ApiPetServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PetDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PetDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>9fbe6d59e1e83363038f62d6d74c6b30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/