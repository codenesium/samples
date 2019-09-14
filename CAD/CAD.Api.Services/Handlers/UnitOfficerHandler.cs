using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class UnitOfficerCreatedHandler : INotificationHandler<UnitOfficerCreatedNotification>
	{
		public async Task Handle(UnitOfficerCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitOfficerUpdatedHandler : INotificationHandler<UnitOfficerUpdatedNotification>
	{
		public async Task Handle(UnitOfficerUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitOfficerDeletedHandler : INotificationHandler<UnitOfficerDeletedNotification>
	{
		public async Task Handle(UnitOfficerDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class UnitOfficerCreatedNotification : INotification
	{
		public ApiUnitOfficerServerResponseModel Record { get; private set; }

		public UnitOfficerCreatedNotification(ApiUnitOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitOfficerUpdatedNotification : INotification
	{
		public ApiUnitOfficerServerResponseModel Record { get; private set; }

		public UnitOfficerUpdatedNotification(ApiUnitOfficerServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class UnitOfficerDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public UnitOfficerDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>96778752d49ec54cb9e70a9e4f2069e4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/