using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Services
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
    <Hash>79fc102abcc59130e21f24f5fb5fe30e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/