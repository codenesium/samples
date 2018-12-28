using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class UnitMeasureCreatedHandler : INotificationHandler<UnitMeasureCreatedNotification>
	{
		public async Task Handle(UnitMeasureCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitMeasureUpdatedHandler : INotificationHandler<UnitMeasureUpdatedNotification>
	{
		public async Task Handle(UnitMeasureUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitMeasureDeletedHandler : INotificationHandler<UnitMeasureDeletedNotification>
	{
		public async Task Handle(UnitMeasureDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitMeasureCreatedNotification : INotification
	{
		public ApiUnitMeasureServerResponseModel Record { get; private set; }

		public UnitMeasureCreatedNotification(ApiUnitMeasureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitMeasureUpdatedNotification : INotification
	{
		public ApiUnitMeasureServerResponseModel Record { get; private set; }

		public UnitMeasureUpdatedNotification(ApiUnitMeasureServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitMeasureDeletedNotification : INotification
	{
		public string UnitMeasureCode { get; private set; }

		public UnitMeasureDeletedNotification(string unitMeasureCode)
		{
			this.UnitMeasureCode = unitMeasureCode;
		}
	}
}

/*<Codenesium>
    <Hash>c5ab20ed5577b26df57e5942650c9427</Hash>
</Codenesium>*/