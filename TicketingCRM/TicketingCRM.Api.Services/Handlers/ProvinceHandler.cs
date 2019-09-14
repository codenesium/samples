using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
{
	public class ProvinceCreatedHandler : INotificationHandler<ProvinceCreatedNotification>
	{
		public async Task Handle(ProvinceCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProvinceUpdatedHandler : INotificationHandler<ProvinceUpdatedNotification>
	{
		public async Task Handle(ProvinceUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProvinceDeletedHandler : INotificationHandler<ProvinceDeletedNotification>
	{
		public async Task Handle(ProvinceDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class ProvinceCreatedNotification : INotification
	{
		public ApiProvinceServerResponseModel Record { get; private set; }

		public ProvinceCreatedNotification(ApiProvinceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProvinceUpdatedNotification : INotification
	{
		public ApiProvinceServerResponseModel Record { get; private set; }

		public ProvinceUpdatedNotification(ApiProvinceServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class ProvinceDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public ProvinceDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>dcffd429d818cfe5263df96824ab7934</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/