using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class SpeciesCreatedHandler : INotificationHandler<SpeciesCreatedNotification>
	{
		public async Task Handle(SpeciesCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpeciesUpdatedHandler : INotificationHandler<SpeciesUpdatedNotification>
	{
		public async Task Handle(SpeciesUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpeciesDeletedHandler : INotificationHandler<SpeciesDeletedNotification>
	{
		public async Task Handle(SpeciesDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class SpeciesCreatedNotification : INotification
	{
		public ApiSpeciesServerResponseModel Record { get; private set; }

		public SpeciesCreatedNotification(ApiSpeciesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpeciesUpdatedNotification : INotification
	{
		public ApiSpeciesServerResponseModel Record { get; private set; }

		public SpeciesUpdatedNotification(ApiSpeciesServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class SpeciesDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public SpeciesDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>e6318cfb6af4a31fec676f2485a8a76b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/