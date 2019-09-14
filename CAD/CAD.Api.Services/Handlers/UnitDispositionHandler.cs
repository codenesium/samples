using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class UnitDispositionCreatedHandler : INotificationHandler<UnitDispositionCreatedNotification>
	{
		public async Task Handle(UnitDispositionCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitDispositionUpdatedHandler : INotificationHandler<UnitDispositionUpdatedNotification>
	{
		public async Task Handle(UnitDispositionUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitDispositionDeletedHandler : INotificationHandler<UnitDispositionDeletedNotification>
	{
		public async Task Handle(UnitDispositionDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitDispositionCreatedNotification : INotification
	{
		public ApiUnitDispositionServerResponseModel Record { get; private set; }

		public UnitDispositionCreatedNotification(ApiUnitDispositionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitDispositionUpdatedNotification : INotification
	{
		public ApiUnitDispositionServerResponseModel Record { get; private set; }

		public UnitDispositionUpdatedNotification(ApiUnitDispositionServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitDispositionDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public UnitDispositionDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f934c8276623e295418417ca837c85d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/