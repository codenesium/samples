using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class AdminCreatedHandler : INotificationHandler<AdminCreatedNotification>
	{
		public async Task Handle(AdminCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminUpdatedHandler : INotificationHandler<AdminUpdatedNotification>
	{
		public async Task Handle(AdminUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminDeletedHandler : INotificationHandler<AdminDeletedNotification>
	{
		public async Task Handle(AdminDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class AdminCreatedNotification : INotification
	{
		public ApiAdminServerResponseModel Record { get; private set; }

		public AdminCreatedNotification(ApiAdminServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AdminUpdatedNotification : INotification
	{
		public ApiAdminServerResponseModel Record { get; private set; }

		public AdminUpdatedNotification(ApiAdminServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class AdminDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public AdminDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>83736157cf77f9f5c20a71475acc0da2</Hash>
</Codenesium>*/