using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class TenantCreatedHandler : INotificationHandler<TenantCreatedNotification>
	{
		public async Task Handle(TenantCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TenantUpdatedHandler : INotificationHandler<TenantUpdatedNotification>
	{
		public async Task Handle(TenantUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TenantDeletedHandler : INotificationHandler<TenantDeletedNotification>
	{
		public async Task Handle(TenantDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class TenantCreatedNotification : INotification
	{
		public ApiTenantServerResponseModel Record { get; private set; }

		public TenantCreatedNotification(ApiTenantServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TenantUpdatedNotification : INotification
	{
		public ApiTenantServerResponseModel Record { get; private set; }

		public TenantUpdatedNotification(ApiTenantServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class TenantDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public TenantDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>ad6e5bb8ef4ffa9e8394a997e2fcf139</Hash>
</Codenesium>*/