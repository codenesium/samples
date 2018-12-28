using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>2f545397af761942969e2fc244d6daeb</Hash>
</Codenesium>*/